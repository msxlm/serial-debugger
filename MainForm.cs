using System.Diagnostics;
using System.IO.Ports;
using System.Text;

namespace SerialDebugger
{
    public partial class MainForm : Form
    {
        private enum Direction { None, Sent, Received, ForwardedFromPrimary, ForwardedFromSecondary }

        private static int _uiThreadId;
        private static readonly Encoding Utf8NoBom = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);

        private readonly AppSettings _settings;
        private readonly SerialPort _port = new();
        private readonly SerialPort _forwardPort = new();
        private ForwardingLog? _forwardingLog;
        private readonly object _primaryWriteLock = new();
        private readonly object _forwardWriteLock = new();
        private volatile bool _forwardingEnabled;
        private volatile bool _closingPorts;

        private Direction _lastDirection = Direction.None;
        private DateTime _lastTimestamp;

        private long _sentCount;
        private long _receivedCount;
        private long _forwardedToSecondaryCount;
        private long _forwardedToPrimaryCount;

        private bool _suspendSettingsSave;
        private bool _suspendInputSync;

        public MainForm()
        {
            InitializeComponent();

            _uiThreadId = Environment.CurrentManagedThreadId;

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            _settings = AppSettings.LoadOrCreate();

            InitializeComboItems();
            ApplySettingsToUi();
            WireEvents();
            RefreshPortList();
            UpdateStatusLabel();
        }

        // ---------- initialization ----------

        private void InitializeComboItems()
        {
            comboBoxBaudRate.Items.Clear();
            foreach (int v in AppSettings.BaudRateValues)
                comboBoxBaudRate.Items.Add(v.ToString());

            comboBoxDataBits.Items.Clear();
            comboBoxDataBits.Items.AddRange(AppSettings.DataBitsTexts);

            comboBoxParity.Items.Clear();
            comboBoxParity.Items.AddRange(AppSettings.ParityDisplayTexts);

            comboBoxStopBits.Items.Clear();
            comboBoxStopBits.Items.AddRange(AppSettings.StopBitsTexts);
            comboBoxForwardBaudRate.Items.Clear();
            foreach (int v in AppSettings.BaudRateValues)
                comboBoxForwardBaudRate.Items.Add(v.ToString());
            comboBoxForwardDataBits.Items.AddRange(AppSettings.DataBitsTexts);
            comboBoxForwardParity.Items.AddRange(AppSettings.ParityDisplayTexts);
            comboBoxForwardStopBits.Items.AddRange(AppSettings.StopBitsTexts);

            comboBoxEncoding.Items.Clear();
            comboBoxEncoding.Items.AddRange(AppSettings.EncodingTexts);

            comboBoxNewLineChar.Items.Clear();
            comboBoxNewLineChar.Items.AddRange(AppSettings.NewLineTexts);

            comboBoxAutoBreakInMs.Items.Clear();
            comboBoxAutoBreakInMs.Items.AddRange(new object[] { "0", "200", "500", "1000", "2000", "5000", "10000" });
        }

        private void ApplySettingsToUi()
        {
            _suspendSettingsSave = true;
            try
            {
                comboBoxBaudRate.SelectedItem = _settings.BaudRateConf;
                comboBoxDataBits.SelectedItem = _settings.DataBitsConf;
                comboBoxParity.SelectedIndex = Array.IndexOf(AppSettings.ParityTexts, _settings.ParityConf);
                comboBoxStopBits.SelectedItem = _settings.StopBitsConf;
                comboBoxForwardBaudRate.SelectedItem = _settings.ForwardBaudRateConf;
                comboBoxForwardDataBits.SelectedItem = _settings.ForwardDataBitsConf;
                comboBoxForwardParity.SelectedIndex = Array.IndexOf(AppSettings.ParityTexts, _settings.ForwardParityConf);
                comboBoxForwardStopBits.SelectedItem = _settings.ForwardStopBitsConf;
                comboBoxEncoding.SelectedItem = _settings.TextEncodingConf;
                comboBoxNewLineChar.SelectedItem = _settings.NewLineConf;
                comboBoxAutoBreakInMs.Text = _settings.AutoBreakConf.ToString();
            }
            finally
            {
                _suspendSettingsSave = false;
            }
        }

        private void WireEvents()
        {
            comboBoxPortName.SelectedIndexChanged += (_, _) => OnSettingChanged();
            comboBoxBaudRate.SelectedIndexChanged += (_, _) => OnSettingChanged();
            comboBoxDataBits.SelectedIndexChanged += (_, _) => OnSettingChanged();
            comboBoxParity.SelectedIndexChanged += (_, _) => OnSettingChanged();
            comboBoxStopBits.SelectedIndexChanged += (_, _) => OnSettingChanged();
            comboBoxForwardPortName.SelectedIndexChanged += (_, _) => OnSettingChanged();
            comboBoxForwardBaudRate.SelectedIndexChanged += (_, _) => OnSettingChanged();
            comboBoxForwardDataBits.SelectedIndexChanged += (_, _) => OnSettingChanged();
            comboBoxForwardParity.SelectedIndexChanged += (_, _) => OnSettingChanged();
            comboBoxForwardStopBits.SelectedIndexChanged += (_, _) => OnSettingChanged();
            comboBoxEncoding.SelectedIndexChanged += (_, _) => OnSettingChanged();
            comboBoxNewLineChar.SelectedIndexChanged += (_, _) => OnSettingChanged();
            comboBoxAutoBreakInMs.TextChanged += (_, _) => OnSettingChanged();
            comboBoxAutoBreakInMs.Leave += (_, _) => OnAutoBreakLeave();

            buttonOpenClose.Click += (_, _) => OnOpenCloseClick();
            buttonForward.Click += (_, _) => OnForwardClick();
            buttonSend.Click += async (_, _) => await OnSendAsync();
            buttonClear.Click += (_, _) => OnClear();
            labelRefresh.Click += (_, _) => RefreshPortList();

            tabControlInput.Selected += OnInputTabSelected;

            _port.DataReceived += OnPortDataReceived;
            _port.ErrorReceived += OnPortErrorReceived;
            _forwardPort.DataReceived += OnForwardPortDataReceived;
            _forwardPort.ErrorReceived += OnForwardPortErrorReceived;

            FormClosing += (_, _) => { StopForwarding(); ClosePort(); _port.Dispose(); _forwardPort.Dispose(); };
        }

        // ---------- settings ----------

        private void OnSettingChanged()
        {
            if (_suspendSettingsSave) return;

            string? selectedPort = comboBoxPortName.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedPort))
            {
                _settings.PortNameConf = selectedPort;
            }
            _settings.BaudRateConf = comboBoxBaudRate.SelectedItem?.ToString() ?? _settings.BaudRateConf;
            _settings.DataBitsConf = comboBoxDataBits.SelectedItem?.ToString() ?? _settings.DataBitsConf;
            if (comboBoxParity.SelectedIndex >= 0)
                _settings.ParityConf = AppSettings.ParityTexts[comboBoxParity.SelectedIndex];
            _settings.StopBitsConf = comboBoxStopBits.SelectedItem?.ToString() ?? _settings.StopBitsConf;
            _settings.ForwardPortNameConf = comboBoxForwardPortName.SelectedItem?.ToString() ?? _settings.ForwardPortNameConf;
            _settings.ForwardBaudRateConf = comboBoxForwardBaudRate.SelectedItem?.ToString() ?? _settings.ForwardBaudRateConf;
            _settings.ForwardDataBitsConf = comboBoxForwardDataBits.SelectedItem?.ToString() ?? _settings.ForwardDataBitsConf;
            if (comboBoxForwardParity.SelectedIndex >= 0)
                _settings.ForwardParityConf = AppSettings.ParityTexts[comboBoxForwardParity.SelectedIndex];
            _settings.ForwardStopBitsConf = comboBoxForwardStopBits.SelectedItem?.ToString() ?? _settings.ForwardStopBitsConf;
            _settings.TextEncodingConf = comboBoxEncoding.SelectedItem?.ToString() ?? _settings.TextEncodingConf;
            _settings.NewLineConf = comboBoxNewLineChar.SelectedItem?.ToString() ?? _settings.NewLineConf;

            if (int.TryParse(comboBoxAutoBreakInMs.Text, out int br) && br >= 0 && br <= 10_000)
            {
                _settings.AutoBreakConf = br;
            }

            _settings.Save();
        }

        private void OnAutoBreakLeave()
        {
            if (!int.TryParse(comboBoxAutoBreakInMs.Text, out int br) || br < 0 || br > 10_000)
            {
                comboBoxAutoBreakInMs.Text = _settings.AutoBreakConf.ToString();
            }
        }

        // ---------- ports ----------

        private void RefreshPortList()
        {
            if (_forwardingEnabled) return;
            string? current = comboBoxPortName.SelectedItem?.ToString();
            string preferred = !string.IsNullOrEmpty(current) ? current : _settings.PortNameConf;
            string? currentForward = comboBoxForwardPortName.SelectedItem?.ToString();
            string preferredForward = !string.IsNullOrEmpty(currentForward) ? currentForward : _settings.ForwardPortNameConf;

            _suspendSettingsSave = true;
            try
            {
                if (!_port.IsOpen) comboBoxPortName.Items.Clear();
                comboBoxForwardPortName.Items.Clear();
                string[] ports = SerialPort.GetPortNames();
                Array.Sort(ports);
                if (!_port.IsOpen) comboBoxPortName.Items.AddRange(ports);
                comboBoxForwardPortName.Items.AddRange(ports);

                if (!_port.IsOpen && !string.IsNullOrEmpty(preferred) && comboBoxPortName.Items.Contains(preferred))
                {
                    comboBoxPortName.SelectedItem = preferred;
                }
                else if (!_port.IsOpen && comboBoxPortName.Items.Count > 0)
                {
                    comboBoxPortName.SelectedIndex = 0;
                }
                if (!string.IsNullOrEmpty(preferredForward) && comboBoxForwardPortName.Items.Contains(preferredForward))
                {
                    comboBoxForwardPortName.SelectedItem = preferredForward;
                }
                else
                {
                    foreach (string port in ports)
                    {
                        if (port != comboBoxPortName.SelectedItem?.ToString())
                        {
                            comboBoxForwardPortName.SelectedItem = port;
                            break;
                        }
                    }
                }
            }
            finally
            {
                _suspendSettingsSave = false;
            }
        }

        private void OnOpenCloseClick()
        {
            if (_port.IsOpen)
            {
                ClosePort();
            }
            else
            {
                TryOpenPort();
            }
        }

        private bool TryOpenPort()
        {
            if (_port.IsOpen) return true;

            string? portName = comboBoxPortName.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(portName))
            {
                ShowError("请选择主串口。");
                return false;
            }

            try
            {
                ConfigurePort(_port, portName, _settings.BaudRateConf, _settings.DataBitsConf,
                    _settings.ParityConf, _settings.StopBitsConf);
                _closingPorts = false;
                _port.Open();

                buttonOpenClose.Text = "关闭串口";
                SetPortSettingsEnabled(false);
                Debug.Print($"Opened port {_port.PortName} @ {_port.BaudRate} {_port.DataBits}-{_port.Parity}-{_port.StopBits}");
                return true;
            }
            catch (Exception ex)
            {
                _closingPorts = true;
                ShowError($"打开串口 {portName} 失败：{ex.Message}");
                return false;
            }
        }

        private void ClosePort()
        {
            _closingPorts = true;
            StopForwarding();
            string name = _port.PortName;
            bool wasOpen = _port.IsOpen;
            try { if (_port.IsOpen) _port.Close(); } catch { /* swallow */ }
            buttonOpenClose.Text = "打开串口";
            SetPortSettingsEnabled(true);
            if (wasOpen) Debug.Print($"Closed port {name}");
        }

        private void SetPortSettingsEnabled(bool enabled)
        {
            comboBoxPortName.Enabled = enabled;
            comboBoxBaudRate.Enabled = enabled;
            comboBoxDataBits.Enabled = enabled;
            comboBoxParity.Enabled = enabled;
            comboBoxStopBits.Enabled = enabled;
            labelRefresh.Enabled = !_forwardingEnabled;
        }

        private static void ConfigurePort(SerialPort port, string name, string baudRate,
            string dataBits, string parity, string stopBits)
        {
            port.PortName = name;
            port.BaudRate = int.Parse(baudRate);
            port.DataBits = int.Parse(dataBits);
            port.Parity = AppSettings.ParityValues[Array.IndexOf(AppSettings.ParityTexts, parity)];
            port.StopBits = AppSettings.StopBitsValues[Array.IndexOf(AppSettings.StopBitsTexts, stopBits)];
            port.ReadTimeout = 500;
            port.WriteTimeout = 500;
        }

        private void OnForwardClick()
        {
            if (_forwardingEnabled) { StopForwarding(); return; }

            string? name = comboBoxForwardPortName.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(name)) { ShowError("请选择转发串口。"); return; }
            if (name == comboBoxPortName.SelectedItem?.ToString())
            {
                ShowError("转发时请选择两个不同的串口。");
                return;
            }
            if (!TryOpenPort()) return;

            try
            {
                ConfigurePort(_forwardPort, name, _settings.ForwardBaudRateConf,
                    _settings.ForwardDataBitsConf, _settings.ForwardParityConf, _settings.ForwardStopBitsConf);
                _forwardingLog = new ForwardingLog();
                lock (_forwardWriteLock)
                {
                    _forwardingEnabled = true;
                    _forwardPort.Open();
                }
                buttonForward.Text = "停止转发";
                SetForwardSettingsEnabled(false);
                labelRefresh.Enabled = false;
                Debug.Print($"Forwarding between {_port.PortName} and {_forwardPort.PortName}");
            }
            catch (Exception ex)
            {
                StopForwarding();
                ShowError($"启动串口转发失败：{ex.Message}");
            }
        }

        private void StopForwarding()
        {
            _forwardingEnabled = false;
            lock (_forwardWriteLock)
            {
                try { if (_forwardPort.IsOpen) _forwardPort.Close(); } catch { }
                try { _forwardingLog?.Dispose(); }
                catch (Exception ex) { Debug.Print($"Failed to close forwarding log: {ex}"); }
                _forwardingLog = null;
            }
            buttonForward.Text = "开始转发";
            SetForwardSettingsEnabled(true);
            labelRefresh.Enabled = true;
        }

        private void SetForwardSettingsEnabled(bool enabled)
        {
            comboBoxForwardPortName.Enabled = enabled;
            comboBoxForwardBaudRate.Enabled = enabled;
            comboBoxForwardDataBits.Enabled = enabled;
            comboBoxForwardParity.Enabled = enabled;
            comboBoxForwardStopBits.Enabled = enabled;
        }

        // ---------- send / receive ----------

        private async Task OnSendAsync()
        {
            if (!_port.IsOpen && !TryOpenPort()) return;

            byte[] payload;
            try
            {
                payload = BuildPayload();
            }
            catch (Exception ex)
            {
                ShowError($"输入内容无效：{ex.Message}");
                return;
            }

            if (payload.Length == 0) return;

            buttonSend.Enabled = false;
            try
            {
                Exception? writeError = await Task.Run(() =>
                {
                    try { lock (_primaryWriteLock) _port.Write(payload, 0, payload.Length); return (Exception?)null; }
                    catch (Exception ex) { return ex; }
                });

                if (writeError != null)
                {
                    ShowError($"发送失败：{writeError.Message}");
                    ClosePort();
                    return;
                }

                Interlocked.Add(ref _sentCount, payload.Length);
                AppendData(Direction.Sent, payload);
                UpdateStatusLabel();
                Debug.Print($"Sent {payload.Length} bytes: {HexHelper.FormatHex(payload)}");
            }
            finally
            {
                buttonSend.Enabled = true;
            }
        }

        private byte[] BuildPayload()
        {
            if (tabControlInput.SelectedTab == tabPageHexInput)
            {
                return HexHelper.ParseHex(textBoxHexInput.Text);
            }
            return EncodeTextWithNewLine(textBoxTextInput.Text);
        }

        private byte[] EncodeTextWithNewLine(string text)
        {
            Encoding enc = ResolveEncoding(_settings.TextEncodingConf);
            string newline = ResolveNewLine(_settings.NewLineConf);
            string[] lines = text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            return enc.GetBytes(string.Join(newline, lines));
        }

        // WinForms multiline TextBox only renders "\r\n" as a line break.
        // Promote bare \r or \n to \r\n so decoded data is visually readable.
        private static string NormalizeLineBreaksForDisplay(string text)
        {
            string[] lines = text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            return string.Join("\r\n", lines);
        }

        private void OnPortDataReceived(object? sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (!_port.IsOpen) return;
                int available = _port.BytesToRead;
                if (available <= 0) return;

                var buffer = new byte[available];
                int read = _port.Read(buffer, 0, available);
                if (read <= 0) return;
                if (read != buffer.Length) Array.Resize(ref buffer, read);

                Interlocked.Add(ref _receivedCount, read);
                Debug.Print($"Received {read} bytes: {HexHelper.FormatHex(buffer)}");

                bool forwarded = false;
                if (_forwardingEnabled)
                {
                    try
                    {
                        lock (_forwardWriteLock)
                        {
                            if (_forwardingEnabled)
                            {
                                _forwardPort.Write(buffer, 0, read);
                                Interlocked.Add(ref _sentCount, read);
                                Interlocked.Add(ref _forwardedToSecondaryCount, read);
                                _forwardingLog!.Write(_port.PortName, _forwardPort.PortName, buffer);
                                forwarded = true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        BeginInvokeSafe(() =>
                        {
                            if (!_forwardingEnabled) return;
                            ShowError($"串口转发出错：{ex.Message}");
                            StopForwarding();
                        });
                    }
                }

                Direction direction = forwarded ? Direction.ForwardedFromPrimary : Direction.Received;
                BeginInvokeSafe(() =>
                {
                    AppendData(direction, buffer);
                    UpdateStatusLabel();
                });
            }
            catch (Exception ex)
            {
                BeginInvokeSafe(() =>
                {
                    if (_closingPorts) return;
                    ShowError($"主串口出错：{ex.Message}");
                    ClosePort();
                });
            }
        }

        private void OnForwardPortDataReceived(object? sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (!_forwardingEnabled || !_forwardPort.IsOpen) return;
                int available = _forwardPort.BytesToRead;
                if (available <= 0) return;
                var buffer = new byte[available];
                int read = _forwardPort.Read(buffer, 0, available);
                if (read <= 0) return;
                if (read != buffer.Length) Array.Resize(ref buffer, read);

                Interlocked.Add(ref _receivedCount, read);
                bool forwarded = false;
                lock (_forwardWriteLock)
                {
                    if (_forwardingEnabled)
                    {
                        lock (_primaryWriteLock)
                            _port.Write(buffer, 0, read);
                        Interlocked.Add(ref _sentCount, read);
                        Interlocked.Add(ref _forwardedToPrimaryCount, read);
                        _forwardingLog!.Write(_forwardPort.PortName, _port.PortName, buffer);
                        forwarded = true;
                    }
                }
                BeginInvokeSafe(() =>
                {
                    if (forwarded) AppendData(Direction.ForwardedFromSecondary, buffer);
                    UpdateStatusLabel();
                });
            }
            catch (Exception ex)
            {
                BeginInvokeSafe(() =>
                {
                    if (!_forwardingEnabled) return;
                    ShowError($"串口转发出错：{ex.Message}");
                    StopForwarding();
                });
            }
        }

        private void OnForwardPortErrorReceived(object? sender, SerialErrorReceivedEventArgs e)
        {
            BeginInvokeSafe(() =>
            {
                if (!_forwardingEnabled) return;
                ShowError($"转发串口出错：{DescribeSerialError(e.EventType)}");
                StopForwarding();
            });
        }

        private void OnPortErrorReceived(object? sender, SerialErrorReceivedEventArgs e)
        {
            BeginInvokeSafe(() =>
            {
                if (_closingPorts) return;
                ShowError($"主串口出错：{DescribeSerialError(e.EventType)}");
                ClosePort();
            });
        }

        // ---------- input tab conversion ----------

        private void OnInputTabSelected(object? sender, TabControlEventArgs e)
        {
            if (_suspendInputSync) return;
            _suspendInputSync = true;
            try
            {
                if (e.TabPage == tabPageHexInput)
                {
                    byte[] bytes = EncodeTextWithNewLine(textBoxTextInput.Text);
                    textBoxHexInput.Text = HexHelper.FormatHex(bytes);
                }
                else if (e.TabPage == tabPageTextInput)
                {
                    try
                    {
                        byte[] bytes = HexHelper.ParseHex(textBoxHexInput.Text);
                        Encoding enc = ResolveEncoding(_settings.TextEncodingConf);
                        textBoxTextInput.Text = NormalizeLineBreaksForDisplay(enc.GetString(bytes));
                    }
                    catch (FormatException ex)
                    {
                        ShowError($"十六进制输入无效：{ex.Message}");
                    }
                }
            }
            finally
            {
                _suspendInputSync = false;
            }
        }

        // ---------- display ----------

        private void AppendData(Direction dir, byte[] bytes)
        {
            DateTime now = DateTime.Now;
            bool coalesce = dir == _lastDirection &&
                            (now - _lastTimestamp).TotalMilliseconds <= _settings.AutoBreakConf;

            Encoding enc = ResolveEncoding(_settings.TextEncodingConf);
            string text = NormalizeLineBreaksForDisplay(enc.GetString(bytes));
            string hex = HexHelper.FormatHex(bytes);

            string textChunk;
            string hexChunk;

            if (coalesce)
            {
                textChunk = text;
                hexChunk = " " + hex;
            }
            else
            {
                string prefix = dir switch
                {
                    Direction.Sent => ">>",
                    Direction.ForwardedFromPrimary => $"<< {_port.PortName} → {_forwardPort.PortName}",
                    Direction.ForwardedFromSecondary => $"<< {_forwardPort.PortName} → {_port.PortName}",
                    _ => "<<"
                };
                string separator = textBoxDisplayText.TextLength > 0
                    ? Environment.NewLine + Environment.NewLine
                    : string.Empty;
                string header = $"{separator}{prefix} {now:HH:mm:ss.fff}{Environment.NewLine}";
                textChunk = header + text;
                hexChunk = header + hex;
            }

            textBoxDisplayText.AppendText(textChunk);
            textBoxDisplayHex.AppendText(hexChunk);

            _lastDirection = dir;
            _lastTimestamp = now;
        }

        private void OnClear()
        {
            textBoxDisplayText.Clear();
            textBoxDisplayHex.Clear();
            _lastDirection = Direction.None;
            Interlocked.Exchange(ref _sentCount, 0);
            Interlocked.Exchange(ref _receivedCount, 0);
            Interlocked.Exchange(ref _forwardedToSecondaryCount, 0);
            Interlocked.Exchange(ref _forwardedToPrimaryCount, 0);
            UpdateStatusLabel();
        }

        private void UpdateStatusLabel()
        {
            labelDataStatus.Text =
                $"已发送：{Interlocked.Read(ref _sentCount)}  已接收：{Interlocked.Read(ref _receivedCount)}  " +
                $"主串口→转发串口：{Interlocked.Read(ref _forwardedToSecondaryCount)}  " +
                $"转发串口→主串口：{Interlocked.Read(ref _forwardedToPrimaryCount)}";
        }

        // ---------- helpers ----------

        private static Encoding ResolveEncoding(string name)
        {
            int idx = Array.IndexOf(AppSettings.EncodingTexts, name);
            if (idx < 0) return Utf8NoBom;
            string value = AppSettings.EncodingValues[idx];

            if (string.Equals(value, "UTF8", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(value, "UTF-8", StringComparison.OrdinalIgnoreCase))
            {
                return Utf8NoBom;
            }

            try
            {
                return Encoding.GetEncoding(value);
            }
            catch (Exception ex)
            {
                Debug.Print($"Encoding '{value}' unavailable ({ex.Message}); falling back to UTF-8 (no BOM)");
                if (Environment.CurrentManagedThreadId == _uiThreadId)
                {
                    MessageBox.Show(
                        $"当前系统不支持编码“{name}”，已改用 UTF-8。",
                        "串口调试助手",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                return Utf8NoBom;
            }
        }

        private static string ResolveNewLine(string name)
        {
            int idx = Array.IndexOf(AppSettings.NewLineTexts, name);
            return idx < 0 ? "\n" : AppSettings.NewLineValues[idx];
        }

        private static string DescribeSerialError(SerialError error) => error switch
        {
            SerialError.TXFull => "发送缓冲区已满",
            SerialError.RXOver => "接收缓冲区溢出",
            SerialError.Overrun => "数据溢出",
            SerialError.RXParity => "校验错误",
            SerialError.Frame => "帧错误",
            _ => error.ToString()
        };

        private void BeginInvokeSafe(Action action)
        {
            if (!IsHandleCreated || IsDisposed) return;
            try { BeginInvoke(action); } catch { /* form going away */ }
        }

        private void ShowError(string message)
        {
            MessageBox.Show(this, message, "串口调试助手", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
