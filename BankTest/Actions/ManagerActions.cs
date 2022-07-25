namespace BankTest.Actions;
public static class ManagerActions
{
    public static void Main()
    {
        Menu.Manager();

        Manager account = AccountActions.loggedAccount as Manager;

        int choice = CommonActions.GetNumber();
        switch (choice)
        {
            // Info
            case 1:
                account.Show();
                break;
            // All
            case 2:
                if (account.IsAdmin == false)
                {
                    Console.WriteLine("Can not access. You are not admin");
                }
                else
                    ShowAll();
                break;
            // Find
            case 3:
                Find();
                break;
            // Edit
            case 4:
                Edit();
                break;
            // Add
            case 5:
                Add();
                break;
            // Clean
            case 6:
                Console.Clear();
                break;
            // logout
            case 7:
                AccountActions.loggedAccount.LogOut();
                AccountActions.loggedAccount = null;
                goto case 6;
            // wrong
            default:
                Menu.WrongNumber();
                break;
        }

    }
    static void ShowAll()
    {
        Console.WriteLine("---------------Accounts---------------");

        foreach (Account ac in AccountActions.accounts)
        {
            if (ac is Manager) ac.Show();
            else ac.Show();
        }
    }
    static void Find()
    {
        Menu.ManagerFind();
        int choice = CommonActions.GetNumber();
        switch (choice)
        {
            // id
            case 1:
                bool isSuccess = false;
                do
                {
                    Console.Write("Enter id: ");
                    Guid id;
                    if (Guid.TryParse(Console.ReadLine(), out id))
                    {
                        Find(x => x.Id == id);
                        isSuccess = true;
                    }
                    else
                        Console.WriteLine("Wrong id");
                } while (isSuccess == false);
                
                break;
            // name
            case 2:
                string first = GetPropertiesOfAccount.GetFirstName();
                string last = GetPropertiesOfAccount.GetLastName();
                try
                {
                    AccountActions.accounts.FindAll(x => x.FirstName == first && x.LastName == last).ForEach(a => a.Show());
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("No matches");
                }
                break;
            // email
            case 3:
                string email = GetPropertiesOfAccount.GetEmail();
                Find(x => x.Email == email);
                break;
            default:
                Console.WriteLine("");
                break;
        }
    }
    static void Edit()
    {
        Account? editetAccount;
        Manager account = AccountActions.loggedAccount as Manager;
        Console.Write("Eneter id: ");

        // get account to edit
        try
        {
            Guid id = Guid.Parse(Console.ReadLine());
            editetAccount = AccountActions.accounts.Find(x => x.Id == id);
            if (account == null)
                throw new Exception("Account not found");

            editetAccount.IsValid();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return;
        }
        // show account
        editetAccount.Show();

        // if try to edit manager and is not an admin deny access
        if (editetAccount is Manager && account.IsAdmin == false)
        {
            Console.WriteLine("access deny");
            return;
        }

        EditingAccount(editetAccount, account);
    }
    static void Add()
    {
        Manager account = AccountActions.loggedAccount as Manager;
        string firstName = GetPropertiesOfAccount.GetFirstName();
        string lastName = GetPropertiesOfAccount.GetLastName();

        string? email;
        do
        {
            Console.Write("E-mail: ");
            email = Console.ReadLine();

        } while (CommonActions.EmailCorrect(email));

        string password = GetPropertiesOfAccount.GetPasssword();
        try
        {
            AccountActions.accounts.Add(new BankAccount(firstName, lastName, password, email));

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    static void EditingAccount(Account editetAccount, Manager account)
    {
        // editing
        Console.WriteLine("If not change empty");
        // get first and last name (if is empty set as null)
        string? firstName = GetPropertiesOfAccount.GetLineOrNull("First name: ");
        string? lastName = GetPropertiesOfAccount.GetLineOrNull("Last name: ");

        // getting email and checking if is correct
        string? email;
        do
        {
            email = GetPropertiesOfAccount.GetLineOrNull("E-mail: ");
            if (email == null)
                break;
        } while (CommonActions.EmailCorrect(email, editetAccount));

        // enter new password and clear line
        string? password = GetPropertiesOfAccount.GetLineOrNull("Password: ");
        CommonActions.ClearCurrentConsoleLine();

        // if account is admin you can edit balance
        if (account.IsAdmin && editetAccount is BankAccount)
        {
            Console.Write("Add to balance: ");
            decimal tempBalance;
            decimal.TryParse(Console.ReadLine(), out tempBalance);
            decimal? addToBalance = tempBalance == 0 ? null : tempBalance;
            (editetAccount as BankAccount).Edit(firstName, lastName, password, email, addToBalance);
        }
        else
            editetAccount.Edit(firstName, lastName, password, email);
    }
    
    static void Find(Predicate<Account> match)
    {
        try
        {
            AccountActions.accounts.Find(match).Show();
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("No matches");
        }
    }
}