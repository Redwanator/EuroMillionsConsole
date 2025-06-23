namespace EuroMillionsConsole.Payment;

/// <summary>
/// Interface de gestion d’encaissement
/// </summary>
internal interface ICashRegister
{
    decimal AskForPayment(decimal amountDue);
}
