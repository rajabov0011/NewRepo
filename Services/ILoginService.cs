using LoginChecker.Models;

namespace LoginChecker.Services
{
    internal interface ILoginService
    {
        Credential addCredential(Credential credential);
        void CheckCredentialLogin(Credential credential);
    }
}
