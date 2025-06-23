using EuroMillionsConsole.Interfaces;

namespace EuroMillionsConsole.Services;

/// <summary>
/// Validation du paiement + rendu monnaie
/// </summary>
internal sealed class CashRegister(IUserInteraction ui) : ICashRegister
{
    private readonly IUserInteraction _ui = ui;

    public decimal AskForPayment(decimal amountDue)
    {
        while (true)
        {
            _ui.PrintLine($"Montant à payer : {amountDue:0.00} EUR");
            _ui.Print("Entrez le montant versé (max 100,00 EUR) : ");
            string input = Console.ReadLine() ?? string.Empty;

            if (decimal.TryParse(input, out decimal paid) && paid >= amountDue && paid <= 100)
                return paid;
        }
    }
}
