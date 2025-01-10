namespace BookManagementSystem;

public class BookIndex
{
    private List<Book> _index = new List<Book>();

    public void Add(Book book)
    {
        _index.Add(book);
    }

    public Book? GetByTitle(string title)
    {
        return _index.FirstOrDefault(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
    }

    public List<Book> GetByAuthor(string author)
    {
        return _index.Where(b => b.Author.Equals(author, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public List<Book> GetByGenre(Genre genre)
    {
        return _index.Where(b => b.BookGenre == genre).ToList();
    }

    public List<Book> GetAll()
    {
        return _index;
    }

    public void MergeBook(Book newBook)
    {
        var existingBook = GetByTitle(newBook.Title);
        if (existingBook != null)
        {
            if (!string.IsNullOrEmpty(newBook.Author))
                existingBook.Author = newBook.Author;
            if (newBook.BookGenre != Genre.Unknown)
                existingBook.BookGenre = newBook.BookGenre;
            if (!string.IsNullOrEmpty(newBook.PublicationYear))
                existingBook.PublicationYear = newBook.PublicationYear;
        }
        else
        {
            Add(newBook);
        }
    }
}
