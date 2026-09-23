namespace SerialDebugger
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            panelLeft = new Panel();
            groupBoxForwarding = new GroupBox();
            labelForwardPortName = new Label();
            labelForwardBaudRate = new Label();
            labelForwardDataBits = new Label();
            labelForwardParity = new Label();
            labelForwardStopBits = new Label();
            comboBoxForwardPortName = new ComboBox();
            comboBoxForwardBaudRate = new ComboBox();
            comboBoxForwardDataBits = new ComboBox();
            comboBoxForwardParity = new ComboBox();
            comboBoxForwardStopBits = new ComboBox();
            buttonForward = new Button();
            buttonOpenClose = new Button();
            groupBoxSendSetting = new GroupBox();
            labelAutoBreak = new Label();
            comboBoxAutoBreakInMs = new ComboBox();
            groupBoxEncoding = new GroupBox();
            labelNewLineChar = new Label();
            comboBoxNewLineChar = new ComboBox();
            comboBoxEncoding = new ComboBox();
            labelEncoding = new Label();
            groupBoxSerialPortSetting = new GroupBox();
            labelRefresh = new Label();
            label5 = new Label();
            comboBoxStopBits = new ComboBox();
            label4 = new Label();
            comboBoxParity = new ComboBox();
            comboBoxDataBits = new ComboBox();
            label3 = new Label();
            comboBoxBaudRate = new ComboBox();
            label2 = new Label();
            comboBoxPortName = new ComboBox();
            labelPortName = new Label();
            panelSendArea = new Panel();
            tabControlInput = new TabControl();
            tabPageTextInput = new TabPage();
            textBoxTextInput = new TextBox();
            tabPageHexInput = new TabPage();
            textBoxHexInput = new TextBox();
            panelSendAction = new Panel();
            labelDataStatus = new Label();
            buttonClear = new Button();
            buttonSend = new Button();
            splitContainer1 = new SplitContainer();
            textBoxDisplayText = new TextBox();
            textBoxDisplayHex = new TextBox();
            panelLeft.SuspendLayout();
            groupBoxForwarding.SuspendLayout();
            groupBoxSendSetting.SuspendLayout();
            groupBoxEncoding.SuspendLayout();
            groupBoxSerialPortSetting.SuspendLayout();
            panelSendArea.SuspendLayout();
            tabControlInput.SuspendLayout();
            tabPageTextInput.SuspendLayout();
            tabPageHexInput.SuspendLayout();
            panelSendAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // panelLeft
            // 
            panelLeft.AutoScroll = true;
            panelLeft.Controls.Add(groupBoxForwarding);
            panelLeft.Controls.Add(buttonOpenClose);
            panelLeft.Controls.Add(groupBoxSendSetting);
            panelLeft.Controls.Add(groupBoxEncoding);
            panelLeft.Controls.Add(groupBoxSerialPortSetting);
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Location = new Point(8, 7);
            panelLeft.Margin = new Padding(4, 4, 4, 4);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(424, 971);
            panelLeft.TabIndex = 0;
            // 
            // groupBoxForwarding
            //
            groupBoxForwarding.Controls.Add(labelForwardPortName);
            groupBoxForwarding.Controls.Add(labelForwardBaudRate);
            groupBoxForwarding.Controls.Add(labelForwardDataBits);
            groupBoxForwarding.Controls.Add(labelForwardParity);
            groupBoxForwarding.Controls.Add(labelForwardStopBits);
            groupBoxForwarding.Controls.Add(comboBoxForwardPortName);
            groupBoxForwarding.Controls.Add(comboBoxForwardBaudRate);
            groupBoxForwarding.Controls.Add(comboBoxForwardDataBits);
            groupBoxForwarding.Controls.Add(comboBoxForwardParity);
            groupBoxForwarding.Controls.Add(comboBoxForwardStopBits);
            groupBoxForwarding.Controls.Add(buttonForward);
            groupBoxForwarding.Location = new Point(15, 647);
            groupBoxForwarding.Margin = new Padding(4, 4, 4, 4);
            groupBoxForwarding.Name = "groupBoxForwarding";
            groupBoxForwarding.Padding = new Padding(4, 4, 4, 4);
            groupBoxForwarding.Size = new Size(377, 322);
            groupBoxForwarding.TabIndex = 14;
            groupBoxForwarding.TabStop = false;
            groupBoxForwarding.Text = "串口转发（双向）";
            //
            // forwarding labels
            //
            labelForwardPortName.Location = new Point(8, 33);
            labelForwardPortName.Name = "labelForwardPortName";
            labelForwardPortName.Size = new Size(153, 28);
            labelForwardPortName.TabIndex = 0;
            labelForwardPortName.Text = "串口：";
            labelForwardPortName.TextAlign = ContentAlignment.MiddleLeft;
            labelForwardBaudRate.Location = new Point(8, 80);
            labelForwardBaudRate.Name = "labelForwardBaudRate";
            labelForwardBaudRate.Size = new Size(153, 28);
            labelForwardBaudRate.TabIndex = 2;
            labelForwardBaudRate.Text = "波特率：";
            labelForwardBaudRate.TextAlign = ContentAlignment.MiddleLeft;
            labelForwardDataBits.Location = new Point(8, 127);
            labelForwardDataBits.Name = "labelForwardDataBits";
            labelForwardDataBits.Size = new Size(153, 28);
            labelForwardDataBits.TabIndex = 4;
            labelForwardDataBits.Text = "数据位：";
            labelForwardDataBits.TextAlign = ContentAlignment.MiddleLeft;
            labelForwardParity.Location = new Point(8, 174);
            labelForwardParity.Name = "labelForwardParity";
            labelForwardParity.Size = new Size(153, 28);
            labelForwardParity.TabIndex = 6;
            labelForwardParity.Text = "校验位：";
            labelForwardParity.TextAlign = ContentAlignment.MiddleLeft;
            labelForwardStopBits.Location = new Point(8, 221);
            labelForwardStopBits.Name = "labelForwardStopBits";
            labelForwardStopBits.Size = new Size(153, 28);
            labelForwardStopBits.TabIndex = 8;
            labelForwardStopBits.Text = "停止位：";
            labelForwardStopBits.TextAlign = ContentAlignment.MiddleLeft;
            //
            // comboBoxForwardPortName
            //
            comboBoxForwardPortName.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxForwardPortName.Location = new Point(168, 33);
            comboBoxForwardPortName.Margin = new Padding(4, 4, 4, 4);
            comboBoxForwardPortName.Name = "comboBoxForwardPortName";
            comboBoxForwardPortName.Size = new Size(189, 28);
            comboBoxForwardPortName.TabIndex = 1;
            //
            // comboBoxForwardBaudRate
            //
            comboBoxForwardBaudRate.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxForwardBaudRate.Location = new Point(168, 80);
            comboBoxForwardBaudRate.Margin = new Padding(4, 4, 4, 4);
            comboBoxForwardBaudRate.Name = "comboBoxForwardBaudRate";
            comboBoxForwardBaudRate.Size = new Size(189, 28);
            comboBoxForwardBaudRate.TabIndex = 3;
            //
            // comboBoxForwardDataBits
            //
            comboBoxForwardDataBits.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxForwardDataBits.Location = new Point(168, 127);
            comboBoxForwardDataBits.Margin = new Padding(4, 4, 4, 4);
            comboBoxForwardDataBits.Name = "comboBoxForwardDataBits";
            comboBoxForwardDataBits.Size = new Size(189, 28);
            comboBoxForwardDataBits.TabIndex = 5;
            //
            // comboBoxForwardParity
            //
            comboBoxForwardParity.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxForwardParity.Location = new Point(168, 174);
            comboBoxForwardParity.Margin = new Padding(4, 4, 4, 4);
            comboBoxForwardParity.Name = "comboBoxForwardParity";
            comboBoxForwardParity.Size = new Size(189, 28);
            comboBoxForwardParity.TabIndex = 7;
            //
            // comboBoxForwardStopBits
            //
            comboBoxForwardStopBits.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxForwardStopBits.Location = new Point(168, 221);
            comboBoxForwardStopBits.Margin = new Padding(4, 4, 4, 4);
            comboBoxForwardStopBits.Name = "comboBoxForwardStopBits";
            comboBoxForwardStopBits.Size = new Size(189, 28);
            comboBoxForwardStopBits.TabIndex = 9;
            //
            // buttonForward
            //
            buttonForward.Location = new Point(8, 266);
            buttonForward.Margin = new Padding(4, 4, 4, 4);
            buttonForward.Name = "buttonForward";
            buttonForward.Size = new Size(351, 40);
            buttonForward.TabIndex = 10;
            buttonForward.Text = "开始转发";
            buttonForward.UseVisualStyleBackColor = true;
            //
            // buttonOpenClose
            // 
            buttonOpenClose.Location = new Point(15, 301);
            buttonOpenClose.Margin = new Padding(4, 4, 4, 4);
            buttonOpenClose.Name = "buttonOpenClose";
            buttonOpenClose.Size = new Size(377, 41);
            buttonOpenClose.TabIndex = 13;
            buttonOpenClose.Text = "打开串口";
            buttonOpenClose.UseVisualStyleBackColor = true;
            // 
            // groupBoxSendSetting
            // 
            groupBoxSendSetting.Controls.Add(labelAutoBreak);
            groupBoxSendSetting.Controls.Add(comboBoxAutoBreakInMs);
            groupBoxSendSetting.Location = new Point(15, 536);
            groupBoxSendSetting.Margin = new Padding(4, 4, 4, 4);
            groupBoxSendSetting.Name = "groupBoxSendSetting";
            groupBoxSendSetting.Padding = new Padding(4, 4, 4, 4);
            groupBoxSendSetting.Size = new Size(377, 98);
            groupBoxSendSetting.TabIndex = 12;
            groupBoxSendSetting.TabStop = false;
            groupBoxSendSetting.Text = "发送设置";
            // 
            // labelAutoBreak
            // 
            labelAutoBreak.Location = new Point(8, 44);
            labelAutoBreak.Margin = new Padding(4, 0, 4, 0);
            labelAutoBreak.Name = "labelAutoBreak";
            labelAutoBreak.Size = new Size(153, 29);
            labelAutoBreak.TabIndex = 24;
            labelAutoBreak.Text = "分段间隔（毫秒）：";
            labelAutoBreak.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBoxAutoBreakInMs
            // 
            comboBoxAutoBreakInMs.FormattingEnabled = true;
            comboBoxAutoBreakInMs.ImeMode = ImeMode.Off;
            comboBoxAutoBreakInMs.Location = new Point(168, 45);
            comboBoxAutoBreakInMs.Margin = new Padding(4, 4, 4, 4);
            comboBoxAutoBreakInMs.Name = "comboBoxAutoBreakInMs";
            comboBoxAutoBreakInMs.Size = new Size(189, 28);
            comboBoxAutoBreakInMs.TabIndex = 23;
            comboBoxAutoBreakInMs.Text = "1000";
            // 
            // groupBoxEncoding
            // 
            groupBoxEncoding.Controls.Add(labelNewLineChar);
            groupBoxEncoding.Controls.Add(comboBoxNewLineChar);
            groupBoxEncoding.Controls.Add(comboBoxEncoding);
            groupBoxEncoding.Controls.Add(labelEncoding);
            groupBoxEncoding.Location = new Point(15, 364);
            groupBoxEncoding.Margin = new Padding(4, 4, 4, 4);
            groupBoxEncoding.Name = "groupBoxEncoding";
            groupBoxEncoding.Padding = new Padding(4, 4, 4, 4);
            groupBoxEncoding.Size = new Size(377, 148);
            groupBoxEncoding.TabIndex = 11;
            groupBoxEncoding.TabStop = false;
            groupBoxEncoding.Text = "文本设置";
            // 
            // labelNewLineChar
            // 
            labelNewLineChar.Location = new Point(8, 93);
            labelNewLineChar.Margin = new Padding(4, 0, 4, 0);
            labelNewLineChar.Name = "labelNewLineChar";
            labelNewLineChar.Size = new Size(153, 29);
            labelNewLineChar.TabIndex = 23;
            labelNewLineChar.Text = "换行符：";
            labelNewLineChar.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBoxNewLineChar
            // 
            comboBoxNewLineChar.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxNewLineChar.FormattingEnabled = true;
            comboBoxNewLineChar.Location = new Point(168, 93);
            comboBoxNewLineChar.Margin = new Padding(4, 4, 4, 4);
            comboBoxNewLineChar.Name = "comboBoxNewLineChar";
            comboBoxNewLineChar.Size = new Size(189, 28);
            comboBoxNewLineChar.TabIndex = 22;
            // 
            // comboBoxEncoding
            // 
            comboBoxEncoding.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEncoding.FormattingEnabled = true;
            comboBoxEncoding.Location = new Point(168, 42);
            comboBoxEncoding.Margin = new Padding(4, 4, 4, 4);
            comboBoxEncoding.Name = "comboBoxEncoding";
            comboBoxEncoding.Size = new Size(189, 28);
            comboBoxEncoding.TabIndex = 21;
            // 
            // labelEncoding
            // 
            labelEncoding.Location = new Point(8, 42);
            labelEncoding.Margin = new Padding(4, 0, 4, 0);
            labelEncoding.Name = "labelEncoding";
            labelEncoding.Size = new Size(153, 29);
            labelEncoding.TabIndex = 20;
            labelEncoding.Text = "文本编码：";
            labelEncoding.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // groupBoxSerialPortSetting
            // 
            groupBoxSerialPortSetting.Controls.Add(labelRefresh);
            groupBoxSerialPortSetting.Controls.Add(label5);
            groupBoxSerialPortSetting.Controls.Add(comboBoxStopBits);
            groupBoxSerialPortSetting.Controls.Add(label4);
            groupBoxSerialPortSetting.Controls.Add(comboBoxParity);
            groupBoxSerialPortSetting.Controls.Add(comboBoxDataBits);
            groupBoxSerialPortSetting.Controls.Add(label3);
            groupBoxSerialPortSetting.Controls.Add(comboBoxBaudRate);
            groupBoxSerialPortSetting.Controls.Add(label2);
            groupBoxSerialPortSetting.Controls.Add(comboBoxPortName);
            groupBoxSerialPortSetting.Controls.Add(labelPortName);
            groupBoxSerialPortSetting.Location = new Point(15, 14);
            groupBoxSerialPortSetting.Margin = new Padding(4, 4, 4, 4);
            groupBoxSerialPortSetting.Name = "groupBoxSerialPortSetting";
            groupBoxSerialPortSetting.Padding = new Padding(4, 4, 4, 4);
            groupBoxSerialPortSetting.Size = new Size(377, 275);
            groupBoxSerialPortSetting.TabIndex = 10;
            groupBoxSerialPortSetting.TabStop = false;
            groupBoxSerialPortSetting.Text = "串口设置";
            // 
            // labelRefresh
            // 
            labelRefresh.Cursor = Cursors.Hand;
            labelRefresh.Image = (Image)resources.GetObject("labelRefresh.Image");
            labelRefresh.Location = new Point(336, 36);
            labelRefresh.Margin = new Padding(4, 0, 4, 0);
            labelRefresh.Name = "labelRefresh";
            labelRefresh.Size = new Size(23, 22);
            labelRefresh.TabIndex = 20;
            // 
            // label5
            // 
            label5.Location = new Point(8, 227);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(153, 29);
            label5.TabIndex = 19;
            label5.Text = "停止位：";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBoxStopBits
            // 
            comboBoxStopBits.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxStopBits.FormattingEnabled = true;
            comboBoxStopBits.Location = new Point(168, 227);
            comboBoxStopBits.Margin = new Padding(4, 4, 4, 4);
            comboBoxStopBits.Name = "comboBoxStopBits";
            comboBoxStopBits.Size = new Size(189, 28);
            comboBoxStopBits.TabIndex = 18;
            // 
            // label4
            // 
            label4.Location = new Point(8, 180);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(153, 29);
            label4.TabIndex = 17;
            label4.Text = "校验位：";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBoxParity
            // 
            comboBoxParity.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxParity.FormattingEnabled = true;
            comboBoxParity.Location = new Point(168, 180);
            comboBoxParity.Margin = new Padding(4, 4, 4, 4);
            comboBoxParity.Name = "comboBoxParity";
            comboBoxParity.Size = new Size(189, 28);
            comboBoxParity.TabIndex = 16;
            // 
            // comboBoxDataBits
            // 
            comboBoxDataBits.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDataBits.FormattingEnabled = true;
            comboBoxDataBits.Location = new Point(168, 131);
            comboBoxDataBits.Margin = new Padding(4, 4, 4, 4);
            comboBoxDataBits.Name = "comboBoxDataBits";
            comboBoxDataBits.Size = new Size(189, 28);
            comboBoxDataBits.TabIndex = 15;
            // 
            // label3
            // 
            label3.Location = new Point(8, 131);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(153, 29);
            label3.TabIndex = 14;
            label3.Text = "数据位：";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBoxBaudRate
            // 
            comboBoxBaudRate.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxBaudRate.FormattingEnabled = true;
            comboBoxBaudRate.Location = new Point(168, 81);
            comboBoxBaudRate.Margin = new Padding(4, 4, 4, 4);
            comboBoxBaudRate.Name = "comboBoxBaudRate";
            comboBoxBaudRate.Size = new Size(189, 28);
            comboBoxBaudRate.TabIndex = 13;
            // 
            // label2
            // 
            label2.Location = new Point(8, 81);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(153, 29);
            label2.TabIndex = 12;
            label2.Text = "波特率：";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBoxPortName
            // 
            comboBoxPortName.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPortName.FormattingEnabled = true;
            comboBoxPortName.Location = new Point(168, 33);
            comboBoxPortName.Margin = new Padding(4, 4, 4, 4);
            comboBoxPortName.Name = "comboBoxPortName";
            comboBoxPortName.Size = new Size(152, 28);
            comboBoxPortName.TabIndex = 11;
            // 
            // labelPortName
            // 
            labelPortName.Location = new Point(8, 33);
            labelPortName.Margin = new Padding(4, 0, 4, 0);
            labelPortName.Name = "labelPortName";
            labelPortName.Size = new Size(153, 29);
            labelPortName.TabIndex = 10;
            labelPortName.Text = "串口：";
            labelPortName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panelSendArea
            // 
            panelSendArea.Controls.Add(tabControlInput);
            panelSendArea.Controls.Add(panelSendAction);
            panelSendArea.Dock = DockStyle.Bottom;
            panelSendArea.Location = new Point(432, 717);
            panelSendArea.Margin = new Padding(4, 4, 4, 4);
            panelSendArea.Name = "panelSendArea";
            panelSendArea.Padding = new Padding(4, 4, 4, 4);
            panelSendArea.Size = new Size(1194, 261);
            panelSendArea.TabIndex = 1;
            // 
            // tabControlInput
            // 
            tabControlInput.Alignment = TabAlignment.Bottom;
            tabControlInput.Controls.Add(tabPageTextInput);
            tabControlInput.Controls.Add(tabPageHexInput);
            tabControlInput.Dock = DockStyle.Fill;
            tabControlInput.Location = new Point(4, 4);
            tabControlInput.Margin = new Padding(4, 4, 4, 4);
            tabControlInput.Multiline = true;
            tabControlInput.Name = "tabControlInput";
            tabControlInput.SelectedIndex = 0;
            tabControlInput.Size = new Size(1186, 181);
            tabControlInput.TabIndex = 3;
            // 
            // tabPageTextInput
            // 
            tabPageTextInput.Controls.Add(textBoxTextInput);
            tabPageTextInput.Location = new Point(4, 4);
            tabPageTextInput.Margin = new Padding(4, 4, 4, 4);
            tabPageTextInput.Name = "tabPageTextInput";
            tabPageTextInput.Padding = new Padding(4, 4, 4, 4);
            tabPageTextInput.Size = new Size(1178, 148);
            tabPageTextInput.TabIndex = 0;
            tabPageTextInput.Text = "文本输入";
            tabPageTextInput.UseVisualStyleBackColor = true;
            // 
            // textBoxTextInput
            // 
            textBoxTextInput.Dock = DockStyle.Fill;
            textBoxTextInput.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxTextInput.Location = new Point(4, 4);
            textBoxTextInput.Margin = new Padding(4, 4, 4, 4);
            textBoxTextInput.Multiline = true;
            textBoxTextInput.Name = "textBoxTextInput";
            textBoxTextInput.PlaceholderText = "输入要发送的文本";
            textBoxTextInput.ScrollBars = ScrollBars.Vertical;
            textBoxTextInput.Size = new Size(1170, 140);
            textBoxTextInput.TabIndex = 0;
            // 
            // tabPageHexInput
            // 
            tabPageHexInput.Controls.Add(textBoxHexInput);
            tabPageHexInput.Location = new Point(4, 4);
            tabPageHexInput.Margin = new Padding(4, 4, 4, 4);
            tabPageHexInput.Name = "tabPageHexInput";
            tabPageHexInput.Padding = new Padding(4, 4, 4, 4);
            tabPageHexInput.Size = new Size(1192, 149);
            tabPageHexInput.TabIndex = 1;
            tabPageHexInput.Text = "十六进制输入";
            tabPageHexInput.UseVisualStyleBackColor = true;
            // 
            // textBoxHexInput
            // 
            textBoxHexInput.Dock = DockStyle.Fill;
            textBoxHexInput.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxHexInput.ImeMode = ImeMode.Off;
            textBoxHexInput.Location = new Point(4, 4);
            textBoxHexInput.Margin = new Padding(4, 4, 4, 4);
            textBoxHexInput.Multiline = true;
            textBoxHexInput.Name = "textBoxHexInput";
            textBoxHexInput.PlaceholderText = "输入十六进制数据，例如 A1 B2 C3";
            textBoxHexInput.ScrollBars = ScrollBars.Vertical;
            textBoxHexInput.Size = new Size(1184, 141);
            textBoxHexInput.TabIndex = 0;
            // 
            // panelSendAction
            // 
            panelSendAction.Controls.Add(labelDataStatus);
            panelSendAction.Controls.Add(buttonClear);
            panelSendAction.Controls.Add(buttonSend);
            panelSendAction.Dock = DockStyle.Bottom;
            panelSendAction.Location = new Point(4, 185);
            panelSendAction.Margin = new Padding(4, 4, 4, 4);
            panelSendAction.Name = "panelSendAction";
            panelSendAction.Padding = new Padding(8, 7, 8, 7);
            panelSendAction.Size = new Size(1186, 72);
            panelSendAction.TabIndex = 2;
            // 
            // labelDataStatus
            // 
            labelDataStatus.Dock = DockStyle.Fill;
            labelDataStatus.Location = new Point(124, 7);
            labelDataStatus.Margin = new Padding(4, 0, 4, 0);
            labelDataStatus.Name = "labelDataStatus";
            labelDataStatus.Size = new Size(934, 58);
            labelDataStatus.TabIndex = 4;
            labelDataStatus.Text = "已发送：0  已接收：0  主串口→转发串口：0  转发串口→主串口：0";
            labelDataStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonClear
            // 
            buttonClear.Dock = DockStyle.Right;
            buttonClear.Location = new Point(1058, 7);
            buttonClear.Margin = new Padding(4, 4, 4, 4);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(120, 58);
            buttonClear.TabIndex = 3;
            buttonClear.Text = "清空";
            buttonClear.UseVisualStyleBackColor = true;
            // 
            // buttonSend
            // 
            buttonSend.Dock = DockStyle.Left;
            buttonSend.Location = new Point(8, 7);
            buttonSend.Margin = new Padding(4, 4, 4, 4);
            buttonSend.Name = "buttonSend";
            buttonSend.Size = new Size(116, 58);
            buttonSend.TabIndex = 2;
            buttonSend.Text = "发送";
            buttonSend.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(432, 7);
            splitContainer1.Margin = new Padding(4, 4, 4, 4);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(textBoxDisplayText);
            splitContainer1.Panel1.Padding = new Padding(8, 7, 8, 7);
            splitContainer1.Panel1MinSize = 100;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(textBoxDisplayHex);
            splitContainer1.Panel2.Padding = new Padding(8, 7, 8, 7);
            splitContainer1.Panel2MinSize = 100;
            splitContainer1.Size = new Size(1194, 710);
            splitContainer1.SplitterDistance = 584;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 3;
            // 
            // textBoxDisplayText
            // 
            textBoxDisplayText.BackColor = SystemColors.Window;
            textBoxDisplayText.Dock = DockStyle.Fill;
            textBoxDisplayText.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxDisplayText.ImeMode = ImeMode.Off;
            textBoxDisplayText.Location = new Point(8, 7);
            textBoxDisplayText.Margin = new Padding(4, 4, 4, 4);
            textBoxDisplayText.Multiline = true;
            textBoxDisplayText.Name = "textBoxDisplayText";
            textBoxDisplayText.PlaceholderText = "文本收发记录";
            textBoxDisplayText.ReadOnly = true;
            textBoxDisplayText.ScrollBars = ScrollBars.Vertical;
            textBoxDisplayText.Size = new Size(568, 696);
            textBoxDisplayText.TabIndex = 1;
            // 
            // textBoxDisplayHex
            // 
            textBoxDisplayHex.BackColor = SystemColors.Window;
            textBoxDisplayHex.Dock = DockStyle.Fill;
            textBoxDisplayHex.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxDisplayHex.ImeMode = ImeMode.Off;
            textBoxDisplayHex.Location = new Point(8, 7);
            textBoxDisplayHex.Margin = new Padding(4, 4, 4, 4);
            textBoxDisplayHex.Multiline = true;
            textBoxDisplayHex.Name = "textBoxDisplayHex";
            textBoxDisplayHex.PlaceholderText = "十六进制收发记录";
            textBoxDisplayHex.ReadOnly = true;
            textBoxDisplayHex.ScrollBars = ScrollBars.Vertical;
            textBoxDisplayHex.Size = new Size(589, 696);
            textBoxDisplayHex.TabIndex = 1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1634, 985);
            Controls.Add(splitContainer1);
            Controls.Add(panelSendArea);
            Controls.Add(panelLeft);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 4, 4, 4);
            Name = "MainForm";
            Padding = new Padding(8, 7, 8, 7);
            Text = "串口调试助手";
            panelLeft.ResumeLayout(false);
            groupBoxForwarding.ResumeLayout(false);
            groupBoxSendSetting.ResumeLayout(false);
            groupBoxEncoding.ResumeLayout(false);
            groupBoxSerialPortSetting.ResumeLayout(false);
            panelSendArea.ResumeLayout(false);
            tabControlInput.ResumeLayout(false);
            tabPageTextInput.ResumeLayout(false);
            tabPageTextInput.PerformLayout();
            tabPageHexInput.ResumeLayout(false);
            tabPageHexInput.PerformLayout();
            panelSendAction.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelLeft;
        private GroupBox groupBoxForwarding;
        private Label labelForwardPortName;
        private Label labelForwardBaudRate;
        private Label labelForwardDataBits;
        private Label labelForwardParity;
        private Label labelForwardStopBits;
        private ComboBox comboBoxForwardPortName;
        private ComboBox comboBoxForwardBaudRate;
        private ComboBox comboBoxForwardDataBits;
        private ComboBox comboBoxForwardParity;
        private ComboBox comboBoxForwardStopBits;
        private Button buttonForward;
        private GroupBox groupBoxSerialPortSetting;
        private Label label5;
        private ComboBox comboBoxStopBits;
        private Label label4;
        private ComboBox comboBoxParity;
        private ComboBox comboBoxDataBits;
        private Label label3;
        private ComboBox comboBoxBaudRate;
        private Label label2;
        private ComboBox comboBoxPortName;
        private Label labelPortName;
        private Panel panelSendArea;
        private Panel panelSendAction;
        private Label labelDataStatus;
        private Button buttonClear;
        private Button buttonSend;
        private TabControl tabControlInput;
        private TabPage tabPageTextInput;
        private TabPage tabPageHexInput;
        private TextBox textBoxTextInput;
        private TextBox textBoxHexInput;
        private GroupBox groupBoxEncoding;
        private ComboBox comboBoxEncoding;
        private Label labelEncoding;
        private Label labelNewLineChar;
        private ComboBox comboBoxNewLineChar;
        private GroupBox groupBoxSendSetting;
        private Label labelAutoBreak;
        private ComboBox comboBoxAutoBreakInMs;
        private SplitContainer splitContainer1;
        private TextBox textBoxDisplayText;
        private TextBox textBoxDisplayHex;
        private Button buttonOpenClose;
        private Label labelRefresh;
    }
}
