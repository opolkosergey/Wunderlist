using System;
using EPAM.Wunderlist.DataAccess.API;
using EPAM.Wunderlist.Model;
using NLog;

namespace EPAM.Wunderlist.Services.LoggerService
{
    public class FileLoggerService : ILoggerService
    {
        private readonly Logger _logger;

        public FileLoggerService()
        {
            _logger = LogManager.GetCurrentClassLogger();
        }

        public void Debug(string errorMessage) 
            => _logger.Debug($"{errorMessage} at {DateTime.Now}");

        public void Trace(string errorMessage) 
            => _logger.Trace($"{errorMessage} at {DateTime.Now}");

        public void Info(string errorMessage) 
            => _logger.Info($"{errorMessage} at {DateTime.Now}");

        public void Warn(string errorMessage) 
            => _logger.Warn($"{errorMessage} at {DateTime.Now}");

        public void Fatal(string errorMessage)
            => _logger.Fatal($"{errorMessage} at {DateTime.Now}");

        public void Error(string errorMessage) 
            => _logger.Error($"{errorMessage} at {DateTime.Now}");
    }
}
