using System;
using EPAM.Wunderlist.DataAccess.API;
using EPAM.Wunderlist.Model;

namespace EPAM.Wunderlist.Services.LoggerService
{
    public class DatabaseLoggerService : ILoggerService
    {
        private readonly IRepository<LogModel> _logRepository;

        public DatabaseLoggerService(IUnitOfWork unitOfWork)
        {
            if(unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));

            _logRepository = unitOfWork.LogRepository;
        }

        public void Debug(string errorMessage)
        {
            _logRepository.Add(new LogModel
            {
                Log = $"Debug : {errorMessage}",
                Time = DateTime.Now
            });
        }

        public void Trace(string errorMessage)
        {
            _logRepository.Add(new LogModel
            {
                Log = $"Trace : {errorMessage}",
                Time = DateTime.Now
            });
        }

        public void Info(string errorMessage)
        {
            _logRepository.Add(new LogModel
            {
                Log = $"Info : {errorMessage}",
                Time = DateTime.Now
            });
        }

        public void Warn(string errorMessage)
        {
            _logRepository.Add(new LogModel
            {
                Log = $"Warn : {errorMessage}",
                Time = DateTime.Now
            });
        }

        public void Fatal(string errorMessage)
        {
            _logRepository.Add(new LogModel
            {
                Log = $"Fatal : {errorMessage}",
                Time = DateTime.Now
            });
        }

        public void Error(string errorMessage)
        {
            _logRepository.Add(new LogModel
            {
                Log = $"Error : {errorMessage}",
                Time = DateTime.Now
            });
        }
    }
}
