namespace BookManagementSystem;

public class SearchBookCommand : Command
{
    public SearchBookCommand(BookIndex index, string[] commandArguments)
        : base(index, commandArguments)
    {
        if (commandArguments.Length < 1)
        {
            IsValid = false;
        }
    }

    public override void Execute()
    {
        if (!IsValid)
        {
            Console.Error.WriteLine("Invalid number of arguments for search command.");
            return;
        }

        string searchType = Arguments[0].ToLower();

        if (searchType == "title" && Arguments.Length >= 2)
        {
            var book = Index.GetByTitle(Arguments[1]);
            if (book != null)
            {
                book.DisplayBook();
            }
            else
            {
                Console.WriteLine("Book not found!");
            }
        }
        else if (searchType == "author" && Arguments.Length >= 2)
        {
            var books = Index.GetByAuthor(Arguments[1]);
            foreach (var book in books)
            {
                book.DisplayBook();
                Console.WriteLine();
            }
        }
        else if (searchType == "genre" && Arguments.Length >= 2)
        {
            if (!Enum.TryParse(Arguments[1], true, out Genre genre))
            {
                Console.Error.WriteLine($"Invalid genre '{Arguments[1]}'.");
                return;
            }

            var books = Index.GetByGenre(genre);
            foreach (var book in books)
            {
                book.DisplayBook();
                Console.WriteLine();
            }
        }
        else
        {
            Console.Error.WriteLine("Invalid search type or not enough arguments.");
        }
    }

    public override void Documentation()
    {
        Console.WriteLine("SearchBook command: search <title|author|genre> <value>");
    }
}
