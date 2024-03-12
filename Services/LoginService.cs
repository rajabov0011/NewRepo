using LoginChecker.Brokers;
using LoginChecker.Brokers.Storages;
using LoginChecker.Models;

namespace LoginChecker.Services
{
    internal class LoginService : Services.LoginService.ILoginService
    {
        private readonly IStorageBroker storageBroker;
        public LoginService()
        {
            this.storageBroker = new FileStorageBroker();
        }

        public bool CheckUserLogin(Credential credential)
        {
            foreach(Credential CredentialItem in this.storageBroker.GetAllCredentials()) 
            {
                if (credential.UserName == CredentialItem.UserName && credential.Password == CredentialItem.Password)
                {
                    return true;
                }
            }

            return false;
        }
    }
}