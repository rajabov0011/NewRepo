using System;
using System.IO;
using LoginChecker.Models;

namespace LoginChecker.Brokers.Storages
{
    internal class FileStorageBroker : IStorageBroker
    {
        private const string FilePath = "../../../Assets/Users.txt";

        public FileStorageBroker()
        {
            EnsureFileExists();
        }

        private static Credential[] credentials = 
        {
            new Credential { UserName = "Asadbek", Password = "12345" },
            new Credential { UserName = "Javlonbek", Password = "54321"}
        };
        public Credential[] GetAllCredentials() => credentials;

        public Credential AddUser(Credential credential)
        {
            string credentialLine = $"{credential.UserName}-{credential.Password}\n";
            File.AppendAllText(FilePath, credentialLine);
            return credential;
        }

        private void EnsureFileExists()
        {
            bool fileExists = File.Exists(FilePath);

            if (fileExists is false)
            {
                File.Create(FilePath);
            }
        }
    }
}