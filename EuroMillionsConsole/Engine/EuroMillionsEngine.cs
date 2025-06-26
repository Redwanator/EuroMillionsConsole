using EuroMillionsConsole.Grids;
using EuroMillionsConsole.Interaction;
using EuroMillionsConsole.Payment;
using EuroMillionsConsole.Pricing;

namespace EuroMillionsConsole.Engine;

/// <summary>
/// Moteur principal orchestrant la génération, le paiement et l'affichage des grilles
/// </summary>
public sealed class EuroMillionsEngine(
    IUserInteraction ui,
    IGridGenerator gridGenerator,
    IPriceCalculator priceCalculator,
    ICashRegister cashRegister,
    IGridDisplayService gridDisplay)
{
    private readonly IUserInteraction _ui = ui;
    private readonly IGridGenerator _gridGenerator = gridGenerator;
    private readonly IPriceCalculator _priceCalculator = priceCalculator;
    private readonly ICashRegister _cashRegister = cashRegister;
    private readonly IGridDisplayService _gridDisplay = gridDisplay;

    internal void Run()
    {
        do
        {
            _ui.PrintLine("=== Générateur de grilles EuroMillions ===\r\n");

            int gridCount = _ui.AskInt("Combien de grilles souhaitez-vous générer ?", 1, 10);

            decimal total = _priceCalculator.CalculateTotalPrice(gridCount);
            decimal paid = _cashRegister.AskForPayment(total);
            decimal change = paid - total;

            _ui.PrintLine($"Paiement reçu : {paid:0.00} EUR");
            if (change > 0)
                _ui.PrintLine($"Monnaie rendue : {change:0.00} EUR");

            _ui.PrintLine();

            HashSet<EuroMillionsGrid> uniqueGrids = [];
            while (uniqueGrids.Count < gridCount)
                uniqueGrids.Add(_gridGenerator.Generate());

            _gridDisplay.Display(uniqueGrids);

            _ui.PrintLine();
        }
        while (AskToPlayAgain());
    }

    private bool AskToPlayAgain()
    {
        _ui.Print("Souhaitez-vous rejouer ? (o/n) : ");
        string response = Console.ReadLine() ?? string.Empty;
        return response.Trim().Equals("o", StringComparison.CurrentCultureIgnoreCase);
    }

    internal void DisplayPricePreview(int gridCount, bool debugMode)
    {
        if (debugMode)
            _priceCalculator.DisplayPriceBreakdown(gridCount, _ui);
    }
}
