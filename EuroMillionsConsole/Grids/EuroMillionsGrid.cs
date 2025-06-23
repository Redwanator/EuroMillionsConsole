namespace EuroMillionsConsole.Grids;

/// <summary>
/// Modèle d'une grille avec Numéros et Étoiles
/// </summary>
internal sealed record EuroMillionsGrid
{
    internal IReadOnlyList<int> Numbers { get; }
    internal IReadOnlyList<int> Stars { get; }

    internal EuroMillionsGrid(IEnumerable<int> numbers, IEnumerable<int> stars)
    {
        List<int> orderedNumbers = numbers.OrderBy(n => n).Distinct().ToList();
        List<int> orderedStars = stars.OrderBy(n => n).Distinct().ToList();

        if (orderedNumbers.Count != 5)
            throw new ArgumentException("Une grille doit avoir exactement 5 numéros.");
        if (orderedStars.Count != 2)
            throw new ArgumentException("Une grille doit avoir exactement 2 étoiles.");

        Numbers = orderedNumbers;
        Stars = orderedStars;
    }

    public override string ToString()
    {
        string formattedNumbers = string.Join(" ", Numbers.Select(n => $"{n:00}"));
        string formattedStars = string.Join(" ", Stars.Select(s => $"{s:00}"));
        return $"{formattedNumbers} * {formattedStars}";
    }
}
