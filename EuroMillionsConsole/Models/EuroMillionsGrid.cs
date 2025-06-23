namespace EuroMillionsConsole.Models;

/// <summary>
/// Modèle d'une grille avec Numéros et Étoiles
/// </summary>
internal sealed class EuroMillionsGrid
{
    internal IReadOnlyList<int> Numbers { get; }
    internal IReadOnlyList<int> Stars { get; }

    internal EuroMillionsGrid(IEnumerable<int> numbers, IEnumerable<int> stars)
    {
        var orderedNumbers = numbers.OrderBy(n => n).Distinct().ToList();
        var orderedStars = stars.OrderBy(n => n).Distinct().ToList();

        if (orderedNumbers.Count != 5)
            throw new ArgumentException("Une grille doit avoir exactement 5 numéros.");
        if (orderedStars.Count != 2)
            throw new ArgumentException("Une grille doit avoir exactement 2 étoiles.");

        Numbers = orderedNumbers;
        Stars = orderedStars;
    }

    public override string ToString()
    {
        return $"Numéros : {string.Join(" ", Numbers)} - Étoiles : {string.Join(" ", Stars)}";
    }

    public override bool Equals(object? obj)
    {
        if (obj is not EuroMillionsGrid other)
            return false;

        return Numbers.SequenceEqual(other.Numbers) && Stars.SequenceEqual(other.Stars);
    }

    public override int GetHashCode()
    {
        return string.Join(",", Numbers).GetHashCode() ^ string.Join(",", Stars).GetHashCode();
    }
}
