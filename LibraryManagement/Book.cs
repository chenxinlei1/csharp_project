namespace LibraryManagement.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public int Year { get; set; }  // 添加 Year 属性

        // 构造函数：接受 id、title、author、category 和 year
        public Book(int id, string title, string author, string category, int year)
        {
            Id = id;
            Title = title;
            Author = author;
            Category = category;
            Year = year;
        }

        // 重写 ToString 方法，返回书籍的详细信息
        public override string ToString()
        {
            return $"{Title} by {Author} ({Year}) - {Category}";
        }
    }
}
