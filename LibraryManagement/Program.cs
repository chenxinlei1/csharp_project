using LibraryManagement.Commands;
using LibraryManagement.Models;
using LibraryManagement.Services;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var library = new Library();
        var localizationService = new LocalizationService();

        var commands = new Dictionary<string, (ICommand Command, string Description)>
        {
            { "add", (new AddCommand(library), "Add a new book") },
            { "list", (new ListBooksCommand(library), "List all books") },
            { "search", (new SearchCommand(library), "Search for books") },
            { "save", (new SaveCommand(library), "Save library to a file") },
            { "load", (new LoadCommand(library), "Load library from a file") },
            { "lang", (new ChangeLanguageCommand(localizationService), "Change application language") },
            { "read_json", (new ReadJsonCommand(library), "Read library data from a JSON file") },
            { "write_json", (new WriteJsonCommand(library), "Write library data to a JSON file") },
            { "exit", (new ExitCommand(), "Exit the application") },
            { "help", (new HelpCommand(commands), "Show available commands") } // 确保添加了 help
        };

        var interpreter = new CommandInterpreter(commands.ToDictionary(k => k.Key, k => k.Value.Command));

        Console.WriteLine("Welcome to the Library Management System!");
        Console.WriteLine("Type 'help' for a list of commands.");

        // 无限循环，直到用户输入 exit
        while (true)
        {
            Console.Write("$ ");
            var input = Console.ReadLine();
            if (input != null)
            {
                interpreter.InterpretCommand(input); // 根据用户输入解释并执行命令
            }
        }
    }
}
