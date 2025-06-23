using EuroMillionsConsole.Engine;
using EuroMillionsConsole.Grids;
using EuroMillionsConsole.Interaction;
using EuroMillionsConsole.Payment;
using EuroMillionsConsole.Pricing;
using EuroMillionsConsole.Randomization;

namespace EuroMillionsConsole;

/// <summary>
/// Entrée de l’application
/// </summary>
internal static class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        IRandomNumberProvider provider = new RandomNumberProvider();
        IGridGenerator generator = new GridGenerator(provider);
        IPriceCalculator priceCalc = new PriceCalculator();
        IUserInteraction ui = new ConsoleUserInteraction();
        ICashRegister cashRegister = new CashRegister(ui);
        IGridDisplayService gridDisplay = new GridDisplayService(ui);

        EuroMillionsEngine engine = new(generator, priceCalc, ui, cashRegister, gridDisplay);
        engine.Run();
    }
}
