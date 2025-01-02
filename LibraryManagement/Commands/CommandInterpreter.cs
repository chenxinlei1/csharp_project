namespace LibraryManagement.Commands;

public class CommandInterpreter
{
    private readonly Dictionary<string, ICommand> _commands;

    public CommandInterpreter(Dictionary<string, ICommand> commands)
    {
        _commands = commands;
    }

    public void InterpretCommand(string input)
    {
        var parts = input.Split(' ', 2); // 将输入拆分为命令和参数
        var commandName = parts[0];
        var args = parts.Length > 1 ? parts[1].Split(' ') : Array.Empty<string>();

        if (_commands.TryGetValue(commandName, out var command))
        {
            command.Execute(args); // 执行对应的命令
        }
        else
        {
            Console.WriteLine($"Unknown command: {commandName}");
        }
    }
}
