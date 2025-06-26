using EuroMillionsConsole.Interaction;

namespace EuroMillionsConsole.Pricing;

/// <summary>
/// Interface de calcul de prix
/// </summary>
public interface IPriceCalculator
{
    decimal CalculateTotalPrice(int gridCount);

    void DisplayPriceBreakdown(int gridCount, IUserInteraction ui);
}
