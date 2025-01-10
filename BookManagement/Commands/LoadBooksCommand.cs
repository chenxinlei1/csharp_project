namespace BookManagementSystem;

public class LoadBooksCommand : Command
{
    public LoadBooksCommand(BookIndex index, string[] commandArguments)
        : base(index, commandArguments)
    {
        if (commandArguments.Length != 1)
        {
            IsValid = false;
        }
    }

    public override void Execute()
    {
        if (!IsValid)
        {
            Console.Error.WriteLine("Invalid arguments for load command.");
            return;
        }

        string filePath = Arguments[0];

        if (!File.Exists(filePath))
        {
            Console.Error.WriteLine($"File {filePath} not found.");
            return;
        }

        try
        {
            using StreamReader reader = new StreamReader(filePath);
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] fields = line.Split(';');

                if (fields.Length < 3)
                {
                    Console.Error.WriteLine($"Invalid data format: {line}");
                    continue;
                }

                string title = fields[0].Trim();
                string author = fields[1].Trim();

                // 尝试将字符串转换为 Genre 枚举
                if (!Enum.TryParse(fields[2].Trim(), true, out Genre genre))
                {
                    Console.Error.WriteLine($"Invalid genre '{fields[2]}'. Defaulting to 'Unknown'.");
                    genre = Genre.Unknown;
                }

                string publicationYear = fields.Length > 3 ? fields[3].Trim() : string.Empty;

                Book book = new Book(title, author, genre, publicationYear);
                Index.MergeBook(book);
            }

            Console.WriteLine($"Books loaded successfully from {filePath}.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error loading books: {ex.Message}");
        }
    }

    public override void Documentation()
    {
        Console.WriteLine("LoadBooks command: load <filePath>");
    }
}
