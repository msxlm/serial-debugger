using System.Globalization;
using System.Text;

namespace SerialDebugger
{
    // The payload is written as hex so arbitrary serial bytes never become garbled text.
    internal sealed class ForwardingLog : IDisposable
    {
        private readonly StreamWriter _writer;

        public static string FilePath => Path.Combine(
            Path.GetDirectoryName(AppSettings.FilePath)!, "forwarding.log");

        public ForwardingLog()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(FilePath)!);
            _writer = new StreamWriter(
                new FileStream(FilePath, FileMode.Append, FileAccess.Write, FileShare.Read),
                new UTF8Encoding(encoderShouldEmitUTF8Identifier: false))
            {
                AutoFlush = true
            };
        }

        public void Write(string sourcePort, string targetPort, byte[] bytes)
        {
            string timestamp = DateTimeOffset.Now.ToString(
                "yyyy-MM-ddTHH:mm:ss.fffzzz", CultureInfo.InvariantCulture);
            _writer.WriteLine($"{timestamp} | {sourcePort} -> {targetPort} | " +
                $"{bytes.Length.ToString(CultureInfo.InvariantCulture)} bytes | {HexHelper.FormatHex(bytes)}");
        }

        public void Dispose() => _writer.Dispose();
    }
}
