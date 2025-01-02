using LibraryManagement.Services;

namespace LibraryManagement.Commands;

public class ChangeLanguageCommand : ICommand
{
    private readonly LocalizationService _localizationService;

    public ChangeLanguageCommand(LocalizationService localizationService)
    {
        _localizationService = localizationService;
    }

    public void Execute(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Please provide a language code (e.g., 'en', 'fr').");
            return;
        }

        var language = args[0].ToLower();
        _localizationService.ChangeLanguage(language);
        Console.WriteLine($"Language changed to {language}.");
    }
}
