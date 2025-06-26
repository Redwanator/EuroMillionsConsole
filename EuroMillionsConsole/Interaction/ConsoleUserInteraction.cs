namespace EuroMillionsConsole.Interaction;

/// <summary>
/// Implémentation concrète pour intéractions console (Console.ReadLine/WriteLine)
/// </summary>
public sealed class ConsoleUserInteraction : IUserInteraction
{
    public int AskInt(string message, int min, int max)
    {
        while (true)
        {
            Console.Write($"{message} ({min}-{max}) : ");
            string input = Console.ReadLine() ?? string.Empty;

            if (int.TryParse(input, out int value) && value >= min && value <= max)
                return value;
        }
    }

    public void PrintLine()
    {
        Console.WriteLine();
    }

    public void PrintLine(string message)
    {
        Console.WriteLine(message);
    }

    public void Print(string message)
    {
        Console.Write(message);
    }
}
