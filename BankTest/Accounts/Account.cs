namespace BankTest;
public class Account
{
    public Guid Id { get; protected set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    private string Password;
    public string Email { get; private set; }

    public readonly DateTime CreatedTime;
    public DateTime LastLogin { get; private set; }
    public bool IsLoggedIn { get; private set; }

    public bool LogIn(string password)
    {
        // check if password is correct and set values
        if (Hashing.GetHashString(password) == Password)
        {
            IsLoggedIn = true;
            LastLogin = DateTime.Now;
            return true;
        }
        return false;
    }

    public void LogOut()
    {
        IsLoggedIn = false;
    }

    public Account(string name, string lastName, string passowrd, string email)
    {
        // creating new unique id
        Id = Guid.NewGuid();

        // set data
        FirstName = name;
        LastName = lastName;
        Password = Hashing.GetHashString(passowrd);

        // email validation
        if (Validation.IsValidEmail(email))
            Email = email;
        else
            throw new InvalidDataException($"invalid email: {email}");

        CreatedTime = DateTime.Now;
    }

    public bool IsValid()
    {
        // check if all values are valid

        if (Id == Guid.Empty) return false;

        if (FirstName == null) return false;

        if (LastName == null) return false;

        if (Password == null) return false;
        if (Password == "") return false;

        if (Email == null) return false;
        if (Email == "") return false;
        if (Validation.IsValidEmail(Email) == false) return false;


        return true;
    }

    public virtual void Show()
    {
        Console.WriteLine("Id: " + Id);
        Console.WriteLine("Name: " + FirstName);
        Console.WriteLine("Last name: " + LastName);
        Console.WriteLine("Email: " + Email);
        Console.WriteLine("Last login: " + LastLogin);
        Console.WriteLine("-------------------------------------");
    }

    public virtual void Edit(string? firstName, string? lastName, string? password, string? email)
    {
        if (firstName != null) FirstName = firstName;
        if (lastName != null) LastName = lastName;
        if (password != null) Password = Hashing.GetHashString(password);
        if (email != null) Email = email;
    }
}

