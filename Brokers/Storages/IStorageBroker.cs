using LoginChecker.Models;

namespace LoginChecker.Brokers.Storages
{
    internal interface IStorageBroker
    {
        Credential[] GetAllCredentials();
        Credential AddUser(Credential credential);
    }
}