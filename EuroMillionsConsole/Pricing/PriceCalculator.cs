using EuroMillionsConsole.Pricing;
using EuroMillionsConsole.UI;

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

    public void DisplayPriceBreakdown(int gridCount, IUserInteraction ui)
    {
        // A appeler dans EuroMillionsEngine.Run() pour afficher le détail des prix
        // _priceCalculator.DisplayPriceBreakdown(gridCount, _ui);

        decimal total = 0m;

        for (int i = 0; i < gridCount; i++)
        {
            decimal unitPrice = GetUnitPrice(i);
            total += unitPrice;
            ui.PrintLine($"Grille {(i + 1):00} :  {unitPrice:0.00} EUR");
        }

        ui.PrintLine($"TOTAL     : {total:0.00} EUR");
    }

    private static decimal GetUnitPrice(int gridIndex)
    {
        int tier = gridIndex / _gridsPerTier;
        return Math.Max(0m, _basePrice - (_discountPerTier * tier));
    }
}
