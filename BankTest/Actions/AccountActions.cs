using BankTest.Actions;

namespace BankTest;
public static class AccountActions
{
    // list of accounts 
    public static List<Account> accounts = new List<Account>();
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

        // display menu
        Menu.Account();
        BankAccount account = loggedAccount as BankAccount;
        int choice = CommonActions.GetNumber();

        switch (choice)
        {
            // info
            case 1:
                account.Show();
                break;
            // transfer
            case 2:
                Transfer(account);
                break;
            // history
            case 3:
                if (account.History.Count == 0)
                {
                    Console.WriteLine("History empty");
                    return;
                }

                Console.WriteLine("---------------History---------------");

                foreach (HistoryNode node in account.History)
                {
                    node.Show();
                }
                break;
            // clan
            case 4:
                Console.Clear();
                break;
            // logout
            case 5:
                loggedAccount.LogOut();
                loggedAccount = null;
                goto case 4;
            // wrong
            default:
                Console.WriteLine("Wrong number");
                break;
        }
    }
    static void Transfer(BankAccount account)
    {
        // get info about receiver and transfer
        Console.Write("To id: ");
        string id = Console.ReadLine();
        Console.Write("Description: ");
        string description = Console.ReadLine();
        Console.Write("Value: ");
        decimal value;
        // try to do transfer (if fail show error)
        try
        {
            value = Convert.ToDecimal(Console.ReadLine());
            // check for account (by id)
            BankAccount reciver = accounts.First(a => a.Id.Equals(Guid.Parse(id)) && a is BankAccount) as BankAccount;
            account.IsValid();
            // show warning about negative balance
            if (CheckIfBalanceGreaterTheZero(account, value)) return;
            account.SetTransfer(reciver, value, description);
        }
        // to do !!!!
        catch (Exception)
        {
            Console.WriteLine("Fail");
        }
    }
    static bool CheckIfBalanceGreaterTheZero(BankAccount account, decimal value)
    {
        if (account.Balance - value < 0)
        {
            // confirm action
            Console.WriteLine("You don't have enough money. Do you want to continue? (y/n)");
            // if something else then 'y' don't do transfer
            if (Console.ReadKey().KeyChar != 'y')
            {
                Console.WriteLine("Transfer ender");
                return true;
            }
        }
        return false;
    }
    
}

