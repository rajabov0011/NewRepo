using LoginChecker.Models;

namespace LoginChecker.Brokers.Storages
{
    internal interface IStorageBroker
    {
        Credential AddCredential(Credential credential);
        Credential[] GetAllCredentials();
        bool CheckUserLogin(Credential credential);
    }
}