using LoginChecker.Models;

namespace LoginChecker.Services.LoginService
{
    internal interface ILoginService
    {
        LoginService CheckUserLogin(Credential credential);
    }
}
