﻿namespace EPAM.Wunderlist.Services.LoggerService
{
    public interface ILogger
    {
        void Debug(string message);
        void Trace(string message);
        void Info(string message);
        void Warn(string message);
        void Fatal(string message);
        void Error(string message);
    }
}
