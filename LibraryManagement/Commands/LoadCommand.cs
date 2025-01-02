using LibraryManagement.Models;
using System;
using System.IO;
using System.Text.Json;

namespace LibraryManagement.Commands
{
    public class LoadCommand : ICommand
    {
        private readonly Library _library;

        public LoadCommand(Library library)
        {
            _library = library;
        }

        public void Execute(string[] args)
        {
            // 确保传入文件路径
            if (args.Length < 1)
            {
                Console.WriteLine("Usage: load [file path]");
                return;
            }

            string path = args[0];

            // 检查文件是否存在
            if (!File.Exists(path))
            {
                Console.WriteLine($"File [{path}] not found, creating a new one...");
                File.WriteAllText(path, "[]");
                return;
            }

            try
            {
                // 读取 JSON 文件
                string jsonString = File.ReadAllText(path);

                // 解析 JSON 数据
                var books = JsonSerializer.Deserialize<List<Book>>(jsonString);

                if (books != null)
                {
                    // 将书籍添加到库中
                    foreach (var book in books)
                    {
                        _library.AddBook(book);
                    }

                    Console.WriteLine($"{books.Count} books loaded from file.");
                }
                else
                {
                    Console.WriteLine("No valid data found in the file.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading the file: {ex.Message}");
            }
        }
    }
}
