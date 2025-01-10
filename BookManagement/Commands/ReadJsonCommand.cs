using System.Text.Json;

namespace BookManagementSystem;

public class ReadJsonCommand : Command
{
    public ReadJsonCommand(BookIndex index, string[] commandArguments)
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
            Console.Error.WriteLine("Invalid arguments for read_json command.");
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
            string jsonString = File.ReadAllText(filePath);
            List<Book>? books = JsonSerializer.Deserialize<List<Book>>(jsonString);

            if (books != null)
            {
                foreach (var book in books)
                {
                    Index.MergeBook(book);
                }
                Console.WriteLine($"Books loaded successfully from {filePath}.");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error reading JSON: {ex.Message}");
        }
    }

    public override void Documentation()
    {
        Console.WriteLine("ReadJson command: read_json <filePath>");
    }
}
