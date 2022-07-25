using BankTest.Actions;

namespace BankTest;
public static class AccountActions
{
    // list of accounts 
    public static List<Account> accounts = new();
    // now logged account
    public static Account? loggedAccount = null;
    public static void Main()
    {
        if (loggedAccount == null) return;

        // check if is valid
        if (!(loggedAccount.IsValid() && loggedAccount.IsLoggedIn))
        {
            loggedAccount.LogOut();
            loggedAccount = null;
            Console.WriteLine("account validation problem");
            return;
        }

        // if manager go to manager actions
        if (loggedAccount is Manager)
        {
            ManagerActions.Main();
            return;
        }
        // if bank account go to bank account actions
        else if (loggedAccount is BankAccount)
        {
            BankAccountActions.Main();
            return;
        }
    }
    public static void Start(ref bool canContinue)
    {
        // show main menu 
        Menu.Main();
        int choice = CommonActions.GetNumber();

        switch (choice)
        {
            // Login
            case 1:
                Login();
                break;
            // Clear
            case 2:
                Console.Clear();
                break;
            // Exit
            case 3:
                canContinue = false;
                break;
            default:
                Menu.WrongNumber();
                break;

        }
    }
    public static void Login()
    {
        // enter login data
        string email = GetPropertiesOfAccount.GetEmail();
        string password = GetPropertiesOfAccount.GetPasssword();


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
}

