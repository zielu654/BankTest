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
                    return;
                }
                Console.WriteLine("---------------Accounts---------------");

                foreach (Account ac in AccountActions.accounts)
                {
                    if (ac is Manager) ac.Show();
                    else ac.Show();
                }
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
                Console.WriteLine("Wrong number");
                break;
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
                Console.Write("Enter id: ");
                try
                {
                    Guid id = Guid.Parse(Console.ReadLine());
                    AccountActions.accounts.Find(x => x.Id == id).Show();
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("No matches");
                }
                break;
            // name
            case 2:
                Console.Write("Enter first name: ");
                string first = Console.ReadLine();
                Console.Write("Enter last name: ");
                string last = Console.ReadLine();
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
                Console.Write("Enter e-mail: ");
                string email = Console.ReadLine();
                try
                {
                    AccountActions.accounts.Find(x => x.Email == email).Show();
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("No matches");
                }
                break;
            default:
                break;
        }
    }
    static void Edit()
    {
        Account editetAccount;
        Manager account = AccountActions.loggedAccount as Manager;
        Console.Write("Eneter id: ");

        // get account to edit
        try
        {

            Guid id = Guid.Parse(Console.ReadLine());
            editetAccount = AccountActions.accounts.Find(x => x.Id == id);
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
        // editing
        Console.WriteLine("If not change empty");
        Console.Write("First name: ");
        string? firstName = Console.ReadLine();
        if (firstName == String.Empty) firstName = null;

        Console.Write("Last name: ");
        string? lastName = Console.ReadLine();
        if (lastName == String.Empty) lastName = null;
        string? email;
        do
        {
            Console.Write("E-mail: ");
            email = Console.ReadLine();
            if (email == String.Empty)
            {
                email = null;
                break;
            }

        } while (CommonActions.EmailCorrect(email, editetAccount));


        // enter new password and clear line
        Console.Write("Password: ");
        string? password = Console.ReadLine();
        if (password == String.Empty) password = null;
        CommonActions.ClearCurrentConsoleLine();

        if (account.IsAdmin && editetAccount is BankAccount)
        {
            Console.Write("Add to balance: ");
            decimal tempBalance;
            decimal.TryParse(Console.ReadLine(), out tempBalance);
            decimal? addToBalance = tempBalance == 0 ? null : tempBalance;
            (editetAccount as BankAccount).Edit(firstName, lastName, password, email, addToBalance);
            return;
        }
        editetAccount.Edit(firstName, lastName, password, email);
    }
    static void Add()
    {
        Manager account = AccountActions.loggedAccount as Manager;
        Console.Write("First name: ");
        string firstName = Console.ReadLine();
        Console.Write("First name: ");
        string lastName = Console.ReadLine();

        string? email;
        do
        {
            Console.Write("E-mail: ");
            email = Console.ReadLine();

        } while (CommonActions.EmailCorrect(email));

        Console.Write("Password: ");
        string password = Console.ReadLine();
        CommonActions.ClearCurrentConsoleLine();
        try
        {
            AccountActions.accounts.Add(new Account(firstName, lastName, password, email));

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}

