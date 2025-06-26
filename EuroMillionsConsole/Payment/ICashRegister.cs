namespace EuroMillionsConsole.Payment;

/// <summary>
/// Interface de gestion d’encaissement
/// </summary>
public interface ICashRegister
{
    decimal AskForPayment(decimal amountDue);
}
