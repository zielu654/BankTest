namespace BankTest;
public class BankAccount : Account
{
    public decimal Balance { get; private set; }
    public List<HistoryNode> History { get; private set; }
    public BankAccount(string name, string lastName, string passowrd, string email) : base(name, lastName, passowrd, email)
    {
        Balance = 0;
        History = new List<HistoryNode>();
    }

    public void SetTransfer(BankAccount receiver, decimal value, string? description = null)
    {
        if (receiver == null) throw new InvalidDataException("receiver is invalid");
        if (receiver.IsValid() == false) throw new InvalidDataException("receiver is invalid");
        if (value < 0) throw new InvalidDataException("value in smaller then 0");
        if (description == null) description = String.Empty;

        try
        {
            receiver.GetTransfer(this, value, description);
        }
        catch (InvalidDataException)
        {
            History.Add(new HistoryNode(0, "failed transaction", this, receiver));
            throw new InvalidDataException("transfer error");
        }

        Balance -= value;
        History.Add(new HistoryNode(value, description, this, receiver));
    }

    public void GetTransfer(BankAccount sender, decimal value, string description)
    {
        if (sender == null) throw new InvalidDataException("sender is invalid");
        if (sender.IsValid() == false) throw new InvalidDataException("sender is invalid");
        if (value < 0) throw new InvalidDataException("value in smaller then 0");

        Balance += value;
        History.Add(new HistoryNode(value, description, sender, this));
    }

    public override void Show()
    {
        Console.WriteLine($"Balance: {Balance}$");
        base.Show();
    }

    public void Edit(string? firstName, string? lastName, string? password, string? email, decimal? addToBalance)
    {
        base.Edit(firstName, lastName, password, email);
        if (addToBalance != null) Balance += (decimal)addToBalance;
    }
}

