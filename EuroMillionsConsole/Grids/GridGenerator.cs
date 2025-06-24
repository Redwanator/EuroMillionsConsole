using EuroMillionsConsole.Randomization;

namespace EuroMillionsConsole.Grids;

/// <summary>
/// Implémentation concrète de génération de grille
/// </summary>
internal sealed class GridGenerator : IGridGenerator
{
    private readonly IRandomNumberProvider _randomProvider;

    internal GridGenerator()
    {
        _randomProvider = new RandomNumberProvider();
    }

    public EuroMillionsGrid Generate()
    {
        IEnumerable<int> numbers = _randomProvider.PickUniqueNumbers(1, 50, 5);
        IEnumerable<int> stars = _randomProvider.PickUniqueNumbers(1, 12, 2);

        return new EuroMillionsGrid(numbers, stars);
    }
}
