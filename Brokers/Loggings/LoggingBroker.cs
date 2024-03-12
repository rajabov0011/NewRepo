using System;

namespace UserManagement.Console.Brokers.Loggings
{
    internal class LoggingBroker : ILoggingBroker
    {
        public void LogInformation(string message)
        {
            System.Console.ForegroundColor = ConsoleColor.DarkBlue;
            System.Console.WriteLine(message);
            System.Console.ResetColor();
        }

        public void LogSucces(string message)
        {
            System.Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine(message);
            System.Console.ResetColor();
        }

        public void LogError(string userMessage)
        {
            System.Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine(userMessage);
            System.Console.ResetColor();
        }

        public void LogError(Exception exception)
        {
            System.Console.ForegroundColor = ConsoleColor.DarkRed;
            System.Console.WriteLine(exception.Message);
            System.Console.ResetColor();
        }
    }
}