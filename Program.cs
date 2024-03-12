using System;
using UserManagement.Console.Models;
using UserManagement.Console.Services;

namespace UserManagement.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ILoginService loginService = new LoginService();

            bool retry = true;
            do
            {
                System.Console.Clear();
                showMenu();
                System.Console.Write("Choose >>> ");
                int myChoose = Convert.ToInt32(System.Console.ReadLine());
                Credential credential = new Credential();

                try
                {
                    switch (myChoose)
                    {
                        case 0:
                            retry = false;
                            System.Console.Clear();
                            System.Console.WriteLine("Thanks, Bye!\n");
                            break;

                        case 1:
                            System.Console.Clear();
                            credential = CreateCredential();
                            loginService.AddCredential(credential);
                            break;

                        case 2:
                            System.Console.Clear();
                            credential = CreateCredential();
                            loginService.CheckCredentialLogin(credential);
                            break;

                        case 3:
                            System.Console.Clear();
                            System.Console.WriteLine("Only Users can use this service.");
                            credential = CreateCredential();
                            loginService.ShowCredentials(credential);
                            break;

                        default:
                            System.Console.Clear();
                            System.Console.WriteLine("This service does not exist!");
                            break;
                    }
                }
                catch (Exception exception)
                {
                    System.Console.WriteLine(exception.Message);
                }

                if (myChoose != 0)
                {
                    System.Console.Write("\nDo you want to use other operations? [yes/no] >>>  ");
                    if (System.Console.ReadLine() == "no")
                    {
                        retry = false;
                        System.Console.Clear();
                        System.Console.WriteLine("Thanks, Bye!\n");
                    }
                }
            } while (retry);
        }

        private static void showMenu()
        {
            System.Console.WriteLine("\t-= Welcome to my project! =-");
            System.Console.WriteLine("1. Sign Up");
            System.Console.WriteLine("2. Log In");
            System.Console.WriteLine("3. View All Users");
            System.Console.WriteLine("0. Exit");
            System.Console.WriteLine("Which service do you want to use?");
        }

        private static Credential CreateCredential()
        {
            Credential credential = new Credential();
            System.Console.Write("Enter your username >>> ");
            string newUsername = System.Console.ReadLine();
            System.Console.Write("Enter your password >>> ");
            string newPassword = System.Console.ReadLine();
            credential.UserName = newUsername;
            credential.Password = newPassword;
            return credential;
        }
    }
}