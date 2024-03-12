using UserManagement.Console.Models;

namespace UserManagement.Console.Brokers.Storages
{
    internal interface IStorageBroker
    {
        Credential AddCredential(Credential credential);
        Credential[] GetAllCredentials();
        bool CheckUserLogin(Credential credential);
    }
}