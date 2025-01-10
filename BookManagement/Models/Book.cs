namespace BookManagementSystem;

public enum Genre
{
    Fiction,
    NonFiction,
    Fantasy,
    Romance,
    Dystopian,
    Adventure,
    HistoricalFiction,
    Unknown
}

public class Book
{
    private string separator = ";";
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;

    // 将 Genre 改为枚举类型
    public Genre BookGenre { get; set; } = Genre.Unknown;
    public string? PublicationYear { get; set; }

    public Book() {}

    public Book(string title, string author, Genre genre, string publicationYear)
    {
        Title = title;
        Author = author;
        BookGenre = genre;
        PublicationYear = publicationYear;
    }

    public void DisplayBook()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Genre: {BookGenre}");
        Console.WriteLine($"Publication Year: {(string.IsNullOrEmpty(PublicationYear) ? "Unknown" : PublicationYear)}");
    }

    public override string ToString()
    {
        return $"{Title}{separator}{Author}{separator}{BookGenre}{separator}{(string.IsNullOrEmpty(PublicationYear) ? "Unknown" : PublicationYear)}";
    }

    // 添加一个只读属性
    public string ShortDescription => $"{Title} ({BookGenre}) by {Author}";
}
