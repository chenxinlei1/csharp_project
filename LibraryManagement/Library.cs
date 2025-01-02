using System.Text.Json;  // 引用 JsonSerializer 命名空间

namespace LibraryManagement.Models
{
    public class Library
    {
        private List<Book> Books { get; set; }

        public Library()
        {
            Books = new List<Book>();
        }

        public void AddBook(Book book)
        {
            Books.Add(book);
        }

        public IEnumerable<Book> ListBooks()
        {
            return Books;
        }

        public IEnumerable<Book> SearchBooks(string criteria, string value)
        {
            switch (criteria.ToLower())
            {
                case "title":
                    return Books.Where(b => b.Title.Contains(value, StringComparison.OrdinalIgnoreCase));
                case "author":
                    return Books.Where(b => b.Author.Contains(value, StringComparison.OrdinalIgnoreCase));
                case "category":
                    return Books.Where(b => b.Category.Contains(value, StringComparison.OrdinalIgnoreCase));
                default:
                    return Enumerable.Empty<Book>();
            }
        }

        public void SaveToFile(string path)
        {
            var json = JsonSerializer.Serialize(Books);  // 将图书信息序列化为 JSON
            File.WriteAllText(path, json);  // 保存到文件
        }

        public void LoadFromFile(string path)
        {
            if (File.Exists(path))
            {
                var json = File.ReadAllText(path);  // 读取文件
                Books = JsonSerializer.Deserialize<List<Book>>(json) ?? new List<Book>();  // 反序列化图书信息
            }
        }
    }
}
