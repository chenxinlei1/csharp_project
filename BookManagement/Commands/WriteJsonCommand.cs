using System.Text.Json;

namespace BookManagementSystem;

public class WriteJsonCommand : Command
{
    public WriteJsonCommand(BookIndex index, string[] commandArguments)
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
            Console.Error.WriteLine("Invalid arguments for write_json command.");
            return;
        }

        string filePath = Arguments[0];

        try
        {
            string jsonString = JsonSerializer.Serialize(Index.GetAll(), new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, jsonString);
            Console.WriteLine($"Books saved successfully to {filePath}.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error writing JSON: {ex.Message}");
        }
    }

    public override void Documentation()
    {
        Console.WriteLine("WriteJson command: write_json <filePath>");
    }
}
