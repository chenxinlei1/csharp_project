namespace BookManagementSystem;

public class AddBookCommand : Command
{
    public AddBookCommand(BookIndex index, string[] commandArguments)
        : base(index, commandArguments)
    {
        if (commandArguments.Length < 3 || commandArguments.Length > 4)
        {
            IsValid = false;
        }
    }

    public override void Execute()
    {
        if (!IsValid)
        {
            Console.Error.WriteLine("Invalid number of arguments for add command.");
            return;
        }

        string title = Arguments[0];
        string author = Arguments[1];

        // 尝试将类别从字符串转换为枚举
        if (!Enum.TryParse(Arguments[2], true, out Genre genre))
        {
            Console.Error.WriteLine($"Invalid genre '{Arguments[2]}'. Defaulting to 'Unknown'.");
            genre = Genre.Unknown;
        }

        string publicationYear = Arguments.Length == 4 ? Arguments[3] : string.Empty;

        if (Index.GetByTitle(title) != null)
        {
            Console.WriteLine($"Book '{title}' already exists in the index.");
            return;
        }

        Book book = new Book(title, author, genre, publicationYear);
        Index.Add(book);
        Console.WriteLine($"Book '{title}' added to the index.");
    }

    public override void Documentation()
    {
        Console.WriteLine("AddBook command: add <title> <author> <genre> [publicationYear]");
    }
}
