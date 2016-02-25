using System;
using EPAM.Wunderlist.DataAccess.API;
using EPAM.Wunderlist.DataAccess.API.Entities;

namespace EPAM.Wunderlist.Services.LoggerService
{
    public class DatabaseLogger : ILogger
    {
        private readonly IRepository<LogModel> _logRepository;

        public DatabaseLogger(IUnitOfWork unitOfWork)
        {
            if(unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));

            _logRepository = unitOfWork.LogRepository;
        }

        public void Debug(string message)
        {
            _logRepository.Add(new LogModel {Log = $"Debug : {message}"});
        }

        public void Trace(string message)
        {
            _logRepository.Add(new LogModel { Log = $"Trace : {message}" });
        }

        public void Info(string message)
        {
            _logRepository.Add(new LogModel { Log = $"Info : {message}" });
        }

        public void Warn(string message)
        {
            _logRepository.Add(new LogModel { Log = $"Warn : {message}" });
        }

        public void Fatal(string message)
        {
            _logRepository.Add(new LogModel { Log = $"Fatal : {message}" });
        }

        public void Error(string message)
        {
            _logRepository.Add(new LogModel { Log = $"Error : {message}" });
        }
    }
}
