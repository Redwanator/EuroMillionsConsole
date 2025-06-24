using EuroMillionsConsole.Interaction;

namespace EuroMillionsConsole.Pricing;

/// <summary>
/// Implémentation concrète du calcul du tarif total en fonction du nombre de grilles
/// </summary>
internal sealed class PriceCalculator : IPriceCalculator
{
    private const decimal _basePrice = 7.50m;
    private const decimal _discountPerTier = 1.50m;
    private const int _gridsPerTier = 2;

    public decimal CalculateTotalPrice(int gridCount)
    {
        if (gridCount is < 1 or > 10)
            throw new ArgumentOutOfRangeException(nameof(gridCount), "Le nombre de grilles doit être compris entre 1 et 10.");

        decimal totalPrice = 0m;

        for (int i = 0; i < gridCount; i++)
            totalPrice += GetUnitPrice(i);

        return totalPrice;
    }

    private decimal GetUnitPrice(int gridIndex)
    {
        int tier = gridIndex / _gridsPerTier;
        return Math.Max(0m, _basePrice - (_discountPerTier * tier));
    }

    public void DisplayPriceBreakdown(int gridCount, IUserInteraction ui, bool debug)
    {
        /*
         * A appeler dans Program.cs pour afficher le détail des prix pour chaque pallier de grilles
         */

        if (debug)
        {
            ui.PrintLine("Note : Le prix diminue de 1,50 EUR toutes les 2 grilles :");

            decimal total = 0m;

            for (int i = 0; i < gridCount; i++)
            {
                decimal unitPrice = GetUnitPrice(i);
                total += unitPrice;
                ui.PrintLine($"Grille {(i + 1):00} :  {unitPrice:0.00} EUR");
            }

            string message = (gridCount == 1) ? "Prix total pour 1 grille :" : $"Prix total pour {gridCount} grilles :";

            ui.PrintLine($"{message} {total:0.00} EUR\r\n");
        }
    }
}
