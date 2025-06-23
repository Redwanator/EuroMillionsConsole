using EuroMillionsConsole.Interfaces;
using EuroMillionsConsole.Models;
using EuroMillionsConsole.Utils;

namespace EuroMillionsConsole;

/// <summary>
/// Entrée de l’application
/// </summary>
internal static class Program
{
    private static void Main(string[] args)
    {
        // Test 1
        var grid = new EuroMillionsGrid(new[] { 5, 12, 23, 37, 42 }, new[] { 2, 9 });
        Console.WriteLine(grid);  // Affichage test

        // Test 2
        IRandomNumberProvider provider = new RandomNumberProvider();

        var numbers = provider.PickUniqueNumbers(1, 50, 5);
        var stars = provider.PickUniqueNumbers(1, 12, 2);

        Console.WriteLine($"Numéros aléatoires : {string.Join(", ", numbers)}");
        Console.WriteLine($"Étoiles aléatoires : {string.Join(", ", stars)}");
    }
}