using LoginChecker.Models;

namespace LoginChecker.Brokers
{
    internal class StorageBroker : IStorageBroker
    {
        private static Credential[] credentials = 
        { 
            new Credential { UserName = "Asadbek", Password = "12345" },
            new Credential { UserName = "Javlonbek", Password = "54321"} 
        };
        public Credential[] GetAllCredentials() => credentials;
    }
}