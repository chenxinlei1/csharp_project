using LibraryManagement.Models;
using System;
using System.Linq;

namespace LibraryManagement.Commands
{
    public class SearchCommand : ICommand
    {
        private readonly Library _library;

        public SearchCommand(Library library)
        {
            _library = library;
        }

        public void Execute(string[] args)
        {
            // 检查输入参数是否足够
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: search [criteria] [value]");
                Console.WriteLine("Available criteria: title, author, category");
                return;
            }

            var criteria = args[0].ToLower();  // 将 criteria 转为小写，统一处理
            var value = args[1].Trim();  // 去除 value 两端的空格

            // 确保 criteria 是有效的
            if (criteria != "title" && criteria != "author" && criteria != "category")
            {
                Console.WriteLine("Invalid criteria. Available criteria: title, author, category");
                return;
            }

            // 调用 Library 类中的 SearchBooks 方法进行搜索
            var results = _library.SearchBooks(criteria, value);

            // 输出搜索结果
            Console.WriteLine("Search results:");
            if (!results.Any())  // 如果没有找到结果
            {
                Console.WriteLine("No books found.");
            }
            else
            {
                foreach (var book in results)
                {
                    Console.WriteLine(book);  // 输出每本书的详细信息
                }
            }
        }
    }
}
