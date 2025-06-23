namespace EuroMillionsConsole.Interfaces;

/// <summary>
/// Interface de calcul de prix
/// </summary>
internal interface IPriceCalculator
{
    decimal CalculateTotalPrice(int gridCount);

    void DisplayPriceBreakdown(int gridCount, IUserInteraction ui);
}
