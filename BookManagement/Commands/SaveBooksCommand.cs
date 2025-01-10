namespace BookManagementSystem;

public class SaveBooksCommand : Command
{
    public SaveBooksCommand(BookIndex index, string[] commandArguments)
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
            Console.Error.WriteLine("Invalid arguments for save command.");
            return;
        }

        string filePath = Arguments[0];

        try
        {
            using StreamWriter writer = new StreamWriter(filePath);
            foreach (var book in Index.GetAll())
            {
                writer.WriteLine(book.ToString());
            }
            Console.WriteLine($"Books saved successfully to {filePath}.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error saving books: {ex.Message}");
        }
    }

    public override void Documentation()
    {
        Console.WriteLine("SaveBooks command: save <filePath>");
    }
}
