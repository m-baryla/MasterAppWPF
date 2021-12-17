using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseAppClass
{
    public enum LogMessageType
    {
        Normal,
        Warning,
        Error,
    }
    public class LogMessageService
    {
        public string Message { get; }

        public LogMessageType Type { get; }

        public DateTime Time { get; }

        public LogMessageService(string message, LogMessageType type, DateTime time)
        {
            this.Message = message;
            this.Type = type;
            this.Time = time;
        }

        public override string ToString() => string.Format("{0} - {1}", (object)this.Time, (object)this.Message);
    }
}
