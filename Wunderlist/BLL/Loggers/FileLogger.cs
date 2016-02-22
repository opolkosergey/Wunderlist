using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace BLL.Loggers
{
    public class FileLogger : ILogger
    {
        private Logger _logger = LogManager.GetCurrentClassLogger();

        public void Log(Action<string> logMethod, string s) => logMethod(s);
    }
}
