using System;
using UserManagement.Console.Models;
using UserManagement.Console.Services;

namespace UserManagement
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
                System.Console.Write("Choose >>> ")
                int myChoose = Convert.ToInt32(System.Console.ReadLine());
                try
                {
                    switch (myChoose)
                    {
                        case 1:
                            System.Console.Clear();
                            Credential credential = new Credential();
                            System.Console.Write("Enter your username >>> ");
                            string username = System.Console.ReadLine();
                            credential.UserName = username;
                            System.Console.Write("Enter your password >>> ");
                            string password = System.Console.ReadLine();
                            credential.Password = password;
                            loginService.addCredential(credential);
                            break;

                        case 2:
                            System.Console.Clear();
                            Credential credential = new Credential();
                            System.Console.Write("Enter your username >>> ");
                            string username = System.Console.ReadLine();
                            credential.UserName = username;
                            System.Console.Write("Enter your password >>> ");
                            string password = System.Console.ReadLine();
                            credential.Password = password;
                            loginService.CheckCredentialLogin(credential);
                            break;

                        case 3:
                            retry = false;
                            System.Console.Clear();
                            System.Console.WriteLine("Thanks, Bye!\n");
                            break;
                    }
                    if (retry != 3)
                    {
                        System.Console.Write("\nDo you want to use other operations? [yes/no] >>>  ");
                        if (System.Console.ReadLine() == "no")
                        {
                            retry = false;
                            System.Console.Clear();
                            System.Console.WriteLine("Thanks, Bye!\n");
                        }
                    }
                }
                catch(Exception exception)
                {
                    System.Console.WriteLine(exception.Message);
                }
            }while (retry)

            void showMenu()
            {
                System.Console.WriteLine("\t-= Welcome to my project! =-")
                System.Console.WriteLine("1. Sign Up")
                System.Console.WriteLine("2. Log In")
                System.Console.WriteLine("3. Exit")
                System.Console.WriteLine("Which service do you want to use?")
            }

        }
    }
}