
namespace BookManagementSystem;

public class CommandInterpreter
{
    private readonly BookIndex _index;
    private readonly Dictionary<string, string> _commands;

    public CommandInterpreter(BookIndex index)
    {
        _index = index;

        _commands = new Dictionary<string, string>
        {
            { "add", "Add a new book to the collection. Ex: add <title> <author> <genre> [publicationYear]" },
            { "search", "Search books by title, author, or genre. Ex: search <title|author|genre> <value>" },
            { "save", "Save all books to a file. Ex: save <filePath>" },
            { "load", "Load books from a file. Ex: load <filePath>" },
            { "write_json", "Save all books to a JSON file. Ex: write_json <filePath>" },
            { "read_json", "Load books from a JSON file. Ex: read_json <filePath>" },
            { "help", "List all available commands." },
            { "exit", "Exit the application." }
        };
    }

    public Command Interpret(string[] arguments)
    {
        if (arguments.Length == 0)
        {
            throw new CommandNotFoundException("No command provided.");
        }

        string commandName = arguments[0].ToLower();
        string[] commandArgs = arguments.Skip(1).ToArray();

        return commandName switch
        {
            "add" => new AddBookCommand(_index, commandArgs),
            "search" => new SearchBookCommand(_index, commandArgs),
            "save" => new SaveBooksCommand(_index, commandArgs),
            "load" => new LoadBooksCommand(_index, commandArgs),
            "write_json" => new WriteJsonCommand(_index, commandArgs),
            "read_json" => new ReadJsonCommand(_index, commandArgs),
            "help" => new HelpCommand(_index, commandArgs, _commands),
            "exit" => new ExitCommand(_index, commandArgs),
            _ => throw new CommandNotFoundException($"Command '{commandName}' not recognized."),
        };
    }
}
