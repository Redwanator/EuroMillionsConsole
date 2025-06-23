namespace EuroMillionsConsole.Interaction;

/// <summary>
/// Interface pour interactions utilisateur
/// </summary>
internal interface IUserInteraction
{
    int AskInt(string message, int min, int max);

    void PrintLine();

    void PrintLine(string message);

    void Print(string message);
}
