namespace BookManagementSystem;

public abstract class Command
{
    protected BookIndex Index = new BookIndex();
    protected bool IsValid = true;
    protected string[] Arguments = Array.Empty<string>();

    public Command() {}

    public Command(BookIndex index, string[] commandArguments)
    {
        Index = index;
        Arguments = commandArguments;
    }

    public abstract void Execute();
    public abstract void Documentation();
}
