using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTest;
public static class CommonActions
{
    public static void ClearCurrentConsoleLine()
    {
        // copied from internet
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
    public static int GetNumber()
    {
        // getting number from user
        int number;
        int.TryParse(Console.ReadLine(), out number);
        return number;
    }
}

