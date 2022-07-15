namespace BankTest;
public class HistoryNode
{
    public readonly Guid Id;
    public readonly DateTime Time;
    public readonly decimal Value;
    public readonly string Description;
    public readonly BankAccount Sender;
    public readonly BankAccount Receiver;

    public HistoryNode(decimal value, string description, BankAccount sender, BankAccount receiver)
    {
        Guid id = Guid.NewGuid();
        Time = DateTime.Now;
        Value = value;
        Description = description;
        Sender = sender;
        Receiver = receiver;
    }

    public void Show()
    {
        Console.WriteLine(Description);
        Console.WriteLine(Value + "$");
        Console.WriteLine("From:");
        Console.WriteLine($"    name: {Sender.FirstName} {Sender.LastName}");
        Console.WriteLine($"    id: {Sender.Id}");
        Console.WriteLine("To:");
        Console.WriteLine($"    name: {Receiver.FirstName} {Receiver.LastName}");
        Console.WriteLine($"    id: {Receiver.Id}");
        Console.WriteLine("Date: " + Time);
    }

}