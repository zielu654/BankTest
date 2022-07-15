using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTest;
public static class CommonActions
{
    public static int GetNumber()
    {
        int number;
        int.TryParse(Console.ReadLine(), out number);
        return number;
    }
    public static void Start(ref bool canContinue)
    {
        Menu.Main();
        int choice = GetNumber();

        switch (choice)
        {
            case 1:
                Login();
                break;
            case 2:
                Console.Clear();
                break;
            case 3:
                canContinue = false;
                break;

        }
    }
    public static void Login()
    {
        // enter login data
        Console.Write("E-mail: ");
        string email = Console.ReadLine();
        Console.Write("Password: ");
        string password = Console.ReadLine();

        // clear line with password
        ClearCurrentConsoleLine();

        // search for matching account
        foreach (Account account in AccountActions.accounts)
        {
            if (account.Email == email)
                if (account.LogIn(password))
                {
                    AccountActions.loggedAccount = account;
                    Console.WriteLine($"Hello {AccountActions.loggedAccount.FirstName} {AccountActions.loggedAccount.LastName}");
                    return;
                }
        }
        Console.WriteLine("Login failed");
    }
    public static void ClearCurrentConsoleLine()
    {
        int currentLineCursor = Console.CursorTop;
        Console.SetCursorPosition(0, Console.CursorTop - 1);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, currentLineCursor);
    }
    public static bool EmailCorrect(string email, Account? account = null)
    {
        // if email exist try again
        if (email != null &&
            AccountActions.accounts.Find(a => a.Email == email && (account == null ? true : (a.Id != account.Id))) != null)
        {
            Console.WriteLine("E-mail already exist");
            return false;
        }
        // if email not valid try again
        if (email != null && Validation.IsValidEmail(email))
        {
            Console.WriteLine("E-mail is not valid");
            return false;
        }
        return true;
    }
}

