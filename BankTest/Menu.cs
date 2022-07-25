namespace BankTest;
public static class Menu
{
    public static void Main()
    {
        Console.WriteLine("1. Login");
        Console.WriteLine("2. Clear");
        Console.WriteLine("3. Exit");
    }

    public static void Account()
    {
        Console.WriteLine("1. Info");
        Console.WriteLine("2. Transfer");
        Console.WriteLine("3. History");
        Console.WriteLine("4. Clean");
        Console.WriteLine("5. Logout");
    }

    public static void Manager()
    {
        Console.WriteLine("1. Info");
        Console.WriteLine("2. All account");
        Console.WriteLine("3. Find account");
        Console.WriteLine("4. Edit account");
        Console.WriteLine("5. Add account");
        Console.WriteLine("6. Clear");
        Console.WriteLine("7. Logout");
    }

    public static void ManagerFind()
    {
        Console.WriteLine("Find by");
        Console.WriteLine("1. Id");
        Console.WriteLine("2. First and last name");
        Console.WriteLine("3. E-mail");
    }

    public static void WrongNumber()
    {
        Console.WriteLine("Wrong number");
    }


}

