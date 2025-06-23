using EuroMillionsConsole.Grids;
using EuroMillionsConsole.Payment;
using EuroMillionsConsole.Pricing;
using EuroMillionsConsole.UI;

namespace EuroMillionsConsole.Engine;

/// <summary>
/// Moteur principal orchestrant la génération, le paiement et l'affichage des grilles
/// </summary>
internal sealed class EuroMillionsEngine(
    IGridGenerator generator,
    IPriceCalculator priceCalculator,
    ICashRegister cashRegister,
    IUserInteraction ui,
    IGridDisplayService gridDisplay)
{
    private readonly IGridGenerator _generator = generator;
    private readonly IPriceCalculator _priceCalculator = priceCalculator;
    private readonly ICashRegister _cashRegister = cashRegister;
    private readonly IUserInteraction _ui = ui;
    private readonly IGridDisplayService _gridDisplay = gridDisplay;

    internal void Run()
    {
        do
        {
            _ui.PrintLine("=== EuroMillions Simulator ===\r\n");

            int gridCount = _ui.AskInt("Combien de grilles souhaitez-vous générer ?", 1, 10);

            //_priceCalculator.DisplayPriceBreakdown(gridCount, _ui); // Affiche le détail des prix pour chaque grille

            decimal total = _priceCalculator.CalculateTotalPrice(gridCount);
            decimal paid = _cashRegister.AskForPayment(total);
            decimal change = paid - total;

            _ui.PrintLine($"Paiement reçu : {paid:0.00} EUR");
            if (change > 0)
                _ui.PrintLine($"Monnaie rendue : {change:0.00} EUR");

            _ui.PrintLine();

            HashSet<EuroMillionsGrid> uniqueGrids = new();
            while (uniqueGrids.Count < gridCount)
                uniqueGrids.Add(_generator.Generate());

            _gridDisplay.Display(uniqueGrids);

            _ui.PrintLine();
        }
        while (AskToPlayAgain());
    }

    private bool AskToPlayAgain()
    {
        _ui.Print("Souhaitez-vous rejouer ? (O/N) : ");
        string response = Console.ReadLine() ?? string.Empty;
        return response.Trim().Equals("O", StringComparison.CurrentCultureIgnoreCase);
    }
}
