using LibraryManagement.Models;  // 引用 Library 和 Book 类所在的命名空间
using LibraryManagement.Services;

namespace LibraryManagement.Commands
{
    public class ListBooksCommand : ICommand
    {
        private readonly Library _library;  // 引用 Library 类实例，用于获取图书列表

        // 构造函数，初始化时传入 Library 实例
        public ListBooksCommand(Library library)
        {
            _library = library;
        }

        public void Execute(string[] args)
        {
            // 检查参数是否足够
            if (args == null || args.Length < 1)
            {
                Console.WriteLine("Usage: list [file path]");
                return;
            }

            var fileName = args[0];
            // Console.WriteLine($"Loading books from file: {fileName}");

            try
            {
                // 尝试从文件加载
                _library.LoadFromFile(fileName);
                Console.WriteLine($"Total books: {_library.ListBooks().Count()}");
            }
            catch (Exception ex)
            {
                // 加载失败时的错误提示
                Console.WriteLine($"Failed to load file: {ex.Message}");
                return;
            }

            // 列出当前库中的书籍
            Console.WriteLine("Books in the library:");

            var books = _library.ListBooks();

            if (books.Any())
            {
                foreach (var book in books)
                {
                    Console.WriteLine(book);  // 调用 Book 的 ToString 方法
                }
            }
            else
            {
                Console.WriteLine("No books available in the library.");
            }
        }
    }
}