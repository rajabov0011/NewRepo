using UserManagement.Console.Brokers.Loggings;
using UserManagement.Console.Brokers.Storages;
using UserManagement.Console.Models;
using System;

namespace UserManagement.Console.Services
{
    internal class LoginService : ILoginService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;

        public LoginService()
        {
            this.storageBroker = new FileStorageBroker();
            this.loggingBroker = new LoggingBroker();
        }

        public Credential AddCredential(Credential credential)
        {
            return credential is null
                ? AddAndLogInvalidCredential()
                : ValidateAndAddCredential(credential);
        }

        public void CheckCredentialLogin(Credential credential)
        {
            if (storageBroker.CheckUserLogin(credential))
            {
                this.loggingBroker.LogSucces("Welcome to User's service!");
            }
            else
            {
                this.loggingBroker.LogError("You entered the wrong login or password, please try again!");
            }
        }

        public void ShowCredentials(Credential credential)
        {
            if (storageBroker.CheckUserLogin(credential))
            {
                Credential[] credentials = this.storageBroker.GetAllCredentials();

                if (credentials.Length == 0)
                {
                    this.loggingBroker.LogError("Credential is empty");
                    return;
                }
                foreach (Credential credentialItem in credentials)
                {
                    this.loggingBroker.LogInformation($"{credentialItem.UserName}-{credentialItem.Password}");
                }

                this.loggingBroker.LogInformation("\t=== End of credentials ===");
            }
            else
            {
                this.loggingBroker.LogError("Unfortunately, you are not available in the list of users!");
            }
        }

        private Credential ValidateAndAddCredential(Credential credential)
        {
            if (String.IsNullOrWhiteSpace(credential.UserName) || String.IsNullOrWhiteSpace(credential.Password))
            {
                this.loggingBroker.LogError("User details missing");

                return new Credential();
            }
            else if (storageBroker.CheckUserLogin(credential))
            {
                this.loggingBroker.LogError("User already exists, use another username");

                return new Credential();
            }
            else
            {
                this.loggingBroker.LogSucces("You have succesfully registered!");

                return this.storageBroker.AddCredential(credential);
            }
        }

        private Credential AddAndLogInvalidCredential()
        {
            this.loggingBroker.LogError("Credential is invalid");

            return new Credential();
        }
    }
}