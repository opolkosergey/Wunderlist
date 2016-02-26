using System;
using EPAM.Wunderlist.DataAccess.API;
using EPAM.Wunderlist.DataAccess.API.Entities;

namespace EPAM.Wunderlist.Services.LoggerService
{
    public class DatabaseLogger : ILogger
    {
        private readonly IRepository<LogDbModel> _logRepository;

        public DatabaseLogger(IUnitOfWork unitOfWork)
        {
            if(unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));

            _logRepository = unitOfWork.LogRepository;
        }

        public void Debug(string message)
        {
            _logRepository.Add(new LogDbModel {Log = $"Debug : {message}", Time = DateTime.Now });
        }

        public void Trace(string message)
        {
            _logRepository.Add(new LogDbModel { Log = $"Trace : {message}", Time = DateTime.Now });
        }

        public void Info(string message)
        {
            _logRepository.Add(new LogDbModel { Log = $"Info : {message}", Time = DateTime.Now });
        }

        public void Warn(string message)
        {
            _logRepository.Add(new LogDbModel { Log = $"Warn : {message}", Time = DateTime.Now });
        }

        public void Fatal(string message)
        {
            _logRepository.Add(new LogDbModel { Log = $"Fatal : {message}", Time = DateTime.Now });
        }

        public void Error(string message)
        {
            _logRepository.Add(new LogDbModel { Log = $"Error : {message}", Time = DateTime.Now });
        }
    }
}
