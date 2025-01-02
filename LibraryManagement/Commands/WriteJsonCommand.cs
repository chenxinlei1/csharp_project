using LibraryManagement.Models;
using System.Text.Json;

namespace LibraryManagement.Commands
{
    public class WriteJsonCommand : ICommand
    {
        private readonly Library _library;

        public WriteJsonCommand(Library library)
        {
            _library = library;
        }

        public void Execute(string[] args)
        {
            Console.WriteLine("Saving library data to JSON file...");
            _library.SaveToFile("library.json");  // 将图书数据保存为 JSON 格式
        }
    }
}
