using System;

namespace BaseClassApp.LogService
{
    public class LogMessage
    {
        public string Message { get; }
        public LogMessageType Type { get; }
        public DateTime Time { get; }

        public LogMessage(string message, LogMessageType type, DateTime time)
        {
            Message = message;
            Type = type;
            Time = time;
        }
        public override string ToString()
        {
            return $"{Time} - {Message}";
        }
    }
}
