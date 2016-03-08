namespace EPAM.Wunderlist.Services.LoggerService
{
    public interface ILoggerService
    {
        void Debug(string errorMessage);
        void Trace(string errorMessage);
        void Info(string errorMessage);
        void Warn(string errorMessage);
        void Fatal(string errorMessage);
        void Error(string errorMessage);
    }
}
