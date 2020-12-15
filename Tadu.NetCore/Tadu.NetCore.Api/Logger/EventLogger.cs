using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Tadu.NetCore.Api.Logger
{
    public class EventLogger : ILogger
    {
        public void Debug(string text)
        {
            EventLog.WriteEntry("MUISFAS-API", text, EventLogEntryType.Information);
        }

        public void Warn(string text)
        {
            EventLog.WriteEntry("MUISFAS-API", text, EventLogEntryType.Warning);
        }

        public void Error(string text)
        {
            EventLog.WriteEntry("MUISFAS-API", text, EventLogEntryType.Error);
        }

        public void Error(string text, Exception ex)
        {
            var message = "";
            if (ex.InnerException != null)
                message = ex.InnerException.Message;
            else
                message = ex.Message;

            Error(text + Environment.NewLine + message + Environment.NewLine + ex.StackTrace);
        }
    }
}
