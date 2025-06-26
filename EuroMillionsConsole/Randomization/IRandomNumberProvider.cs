namespace EuroMillionsConsole.Randomization;

/// <summary>
/// Interface de service pour la génération de nombres entiers uniques aléatoires dans une plage donnée
/// </summary>
public interface IRandomNumberProvider
{
    IEnumerable<int> PickUniqueNumbers(int minInclusive, int maxInclusive, int count);
}
