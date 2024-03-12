using UserManagement.Console.Models;

namespace UserManagement.Console.Services
{
    internal interface ILoginService
    {
        Credential addCredential(Credential credential);
        void CheckCredentialLogin(Credential credential);
        void showCredentials()
    }
}
