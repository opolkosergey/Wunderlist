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
        public void Debug(string s) => _logger.Debug(s);
    
        public void Trace(string s) => _logger.Trace(s);
       
        public void Info(string s) => _logger.Info(s);
        
        public void Warn(string s) => _logger.Warn(s);

        public void Fatal(string s) => _logger.Fatal(s);
        
        public void Error(string s) => _logger.Error(s);   
    }
}
