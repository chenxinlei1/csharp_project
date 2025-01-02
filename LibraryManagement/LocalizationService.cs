namespace LibraryManagement.Services;

public class LocalizationService
{
    private readonly Dictionary<string, Dictionary<string, string>> _localizationData;
    private string _currentLanguage;

    public LocalizationService()
    {
        _currentLanguage = "en"; // 默认语言为英文
        _localizationData = new Dictionary<string, Dictionary<string, string>>
        {
            { "en", new Dictionary<string, string>
                {
                    { "help", "Show help information" },
                    { "add", "Add a new book" },
                    { "list", "List all books" },
                    { "search", "Search for a book" },
                    { "save", "Save library to a file" },
                    { "load", "Load library from a file" },
                    { "exit", "Exit the application" }
                }
            },
            { "fr", new Dictionary<string, string>
                {
                    { "help", "Afficher les informations d'aide" },
                    { "add", "Ajouter un nouveau livre" },
                    { "list", "Lister tous les livres" },
                    { "search", "Rechercher un livre" },
                    { "save", "Enregistrer la bibliothèque dans un fichier" },
                    { "load", "Charger la bibliothèque depuis un fichier" },
                    { "exit", "Quitter l'application" }
                }
            }
        };
    }

    public string GetText(string key)
    {
        if (_localizationData[_currentLanguage].TryGetValue(key, out var value))
        {
            return value;
        }

        return key; // 如果找不到对应的文本，返回 key 本身
    }

    public void ChangeLanguage(string language)
    {
        if (_localizationData.ContainsKey(language))
        {
            _currentLanguage = language;
            Console.WriteLine($"Language changed to {language}");
        }
        else
        {
            Console.WriteLine($"Language '{language}' is not supported.");
        }
    }
}
