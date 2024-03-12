using LoginChecker.Brokers.Loggings;
using LoginChecker.Brokers.Storages;
using LoginChecker.Models;

namespace LoginChecker.Services
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

        public Credential addCredential(Credential credential)
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

        public void showCredentials()
        {
            Credential[] credentials = this.storageBroker.GetAllCredentials();

            if (credentials.Length == 0)
            {
                this.loggingBroker.LogError("Credential is empty");
                return;
            }
            foreach (Credential credential in credentials)
            {
                this.loggingBroker.LogInformation($"{credential.UserName}-{credential.Password}");
            }

            this.loggingBroker.LogInformation("\t=== End of credentials ===");
        }

        private Credential ValidateAndAddCredential(Credential credential)
        {
            if (String.IsNullOrWhiteSpace(credential.UserName) || String.IsNullOrWhiteSpace(credential.Password))
            {
                this.loggingBroker.LogError("User details missing");

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