using EuroMillionsConsole.Engine;
using EuroMillionsConsole.Interaction;

namespace EuroMillionsConsole;

/// <summary>
/// Entrée de l’application
/// </summary>
internal static class Program
{
    private static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        IUserInteraction ui = new ConsoleUserInteraction();

        EuroMillionsEngine engine = new(ui);

        // Passer debug à TRUE pour afficher le détail des prix pour chaque pallier de grilles
        engine.DisplayPricePreview(gridCount: 10, debugMode: true);

        engine.Run();
    }
}
