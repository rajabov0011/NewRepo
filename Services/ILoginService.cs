using UserManagement.Console.Models;

namespace UserManagement.Console.Services
{
    internal interface ILoginService
    {
        Credential AddCredential(Credential credential);
        void CheckCredentialLogin(Credential credential);
        void ShowCredentials(Credential credential);
    }
}
