using EuroMillionsConsole.Configuration;
using EuroMillionsConsole.Engine;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EuroMillionsConsole;

/// <summary>
/// Entrée de l’application
/// </summary>
internal static class Program
{
    private static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        using IHost host = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                services.AddApplicationServices(); // <- on enregistre toutes les dépendances ici
            })
            .Build();

        EuroMillionsEngine engine = host.Services.GetRequiredService<EuroMillionsEngine>();

        // Passer debug à TRUE pour afficher le détail des prix pour chaque pallier de grilles
        engine.DisplayPricePreview(gridCount: 10, debugMode: false);

        engine.Run();
    }
}
