using BookManagementSystem;
using System;
using System.Text; 

public class Program
{
    public static void Main(string[] args)
    {
        BookIndex index = new BookIndex();
        CommandInterpreter interpreter = new CommandInterpreter(index);

        Console.WriteLine("Welcome to the Book Management System!");
        Console.WriteLine("Type 'help' to see available commands.\n");

        while (true)
        {
            Console.Write("$ ");
            string? line = Console.ReadLine();

            if (line == null)
            {
                Console.WriteLine("No input received. Exiting...");
                break;
            }

            List<string> arguments = new List<string>();
            bool inQuotes = false;
            StringBuilder currentArg = new StringBuilder();
            foreach (char c in line)
            {
                if (c == '"') 
                {
                    inQuotes = !inQuotes;
                }
                else if (c == ' ' && !inQuotes) 
                {
                    if (currentArg.Length > 0)
                    {
                        arguments.Add(currentArg.ToString());
                        currentArg.Clear();
                    }
                }
                else
                {
                    currentArg.Append(c);
                }
            }

            if (currentArg.Length > 0)
            {
                arguments.Add(currentArg.ToString());
            }

            string[] commandArgs = arguments.ToArray();

            try
            {
                Command command = interpreter.Interpret(commandArgs);
                command.Execute();
            }
            catch (CommandNotFoundException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
