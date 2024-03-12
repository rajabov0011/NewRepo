using System;

namespace UserManagement.Console.Brokers.Loggings
{
    internal interface ILoggingBroker
    {
        void LogInformation (string message);
        void LogSucces (string message);
        void LogError (String userMessage);
        void LogError(Exception exception);
    }
}