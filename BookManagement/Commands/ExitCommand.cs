namespace BookManagementSystem;

public class ExitCommand : Command
{
    public ExitCommand(BookIndex index, string[] commandArguments)
        : base(index, commandArguments)
    {
    }

    public override void Execute()
    {
        Console.WriteLine("Exiting the application...");
        Environment.Exit(0);
    }

    public override void Documentation()
    {
        Console.WriteLine("Exit command: exit");
    }
}
