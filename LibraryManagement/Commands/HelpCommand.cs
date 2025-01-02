namespace LibraryManagement.Commands;

public class HelpCommand : ICommand
{
    private readonly Dictionary<string, (ICommand Command, string Description)> _commands;

    public HelpCommand(Dictionary<string, (ICommand Command, string Description)> commands)
    {
        _commands = commands;
    }

    public void Execute(string[] args)
    {
        Console.WriteLine("Available commands:");
        foreach (var command in _commands)
        {
            Console.WriteLine($"  {command.Key} - {command.Value.Description}");
        }
    }
}
