namespace LibraryManagement.Commands;

public class ExitCommand : ICommand
{
    public void Execute(string[] args)
    {
        Console.WriteLine("Exiting the application...");
        Environment.Exit(0);
    }
}
