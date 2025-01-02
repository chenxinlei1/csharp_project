using LibraryManagement.Models;  // 引用 Library 和 Book 类所在的命名空间
using LibraryManagement.Services;
using System;

namespace LibraryManagement.Commands
{
    public class AddCommand : ICommand
    {
        private readonly Library _library;

        public AddCommand(Library library)
        {
            _library = library;
        }

        public void Execute(string[] args)
        {
            // 提示用户输入所有图书的详细信息，并使用逗号分隔
            Console.WriteLine("Enter book details in this order: Title, Author, Year, Category");

            // 获取用户输入并通过逗号分隔
            var input = Console.ReadLine();
            var details = input?.Split(',');

            // 如果输入无效或字段不完整，提示用户并退出
            if (details == null || details.Length < 4)
            {
                Console.WriteLine("Invalid input. Please provide all details (Title, Author, Year, Category).");
                return;
            }

            // 创建新的 Book 对象并通过构造函数设置其属性
            try
            {
                var book = new Book(
                    _library.ListBooks().Count() + 1,  // 设置 ID
                    details[0].Trim(),                  // 书名
                    details[1].Trim(),                  // 作者
                    details[3].Trim(),                  // 类别
                    int.Parse(details[2].Trim())        // 出版年份（确保 year 是 int 类型）
                );

                // 将图书添加到图书馆
                _library.AddBook(book);

                // 输出成功添加图书的消息
                Console.WriteLine($"Book '{book.Title}' by {book.Author} added successfully!");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Error parsing input: {ex.Message}. Please ensure Year is an integer.");
            }
        }
    }
}
