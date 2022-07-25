namespace BankTest;
public class Manager : Account
{
    public bool IsAdmin { get; set; }
    public Manager(string name, string lastName, string passowrd, string email, bool isAdmin) : base(name, lastName, passowrd, email)
    {
        IsAdmin = isAdmin;
    }

    public override void Show()
    {
        // if is manager show it
        if (IsAdmin) Console.WriteLine("Admin");
        else Console.WriteLine("Manager");

        base.Show();
    }
}