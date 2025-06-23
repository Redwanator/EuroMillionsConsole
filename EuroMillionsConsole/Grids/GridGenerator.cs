using EuroMillionsConsole.Randomization;

namespace EuroMillionsConsole.Grids;

/// <summary>
/// Implémentation concrète de génération de grille
/// </summary>
internal class GridGenerator(IRandomNumberProvider randomProvider) : IGridGenerator
{
    private readonly IRandomNumberProvider _randomProvider = randomProvider;

    public EuroMillionsGrid Generate()
    {
        IEnumerable<int> numbers = _randomProvider.PickUniqueNumbers(1, 50, 5);
        IEnumerable<int> stars = _randomProvider.PickUniqueNumbers(1, 12, 2);

        return new EuroMillionsGrid(numbers, stars);
    }
}
