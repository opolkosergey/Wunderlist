using System;
using NLog;

namespace EPAM.Wunderlist.Services.LoggerService
{
    public class FileLogger : ILogger
    {
        private readonly Logger _logger;

        public FileLogger()
        {
            _logger = LogManager.GetCurrentClassLogger();
        }

        public void Debug(string message) => _logger.Debug($"{message} at {DateTime.Now}");

        public void Trace(string message) => _logger.Trace($"{message} at {DateTime.Now}");

        public void Info(string message) => _logger.Info($"{message} at {DateTime.Now}");

        public void Warn(string message) => _logger.Warn($"{message} at {DateTime.Now}");

        public void Fatal(string message) => _logger.Fatal($"{message} at {DateTime.Now}");

        public void Error(string message) => _logger.Error($"{message} at {DateTime.Now}");
    }
}
