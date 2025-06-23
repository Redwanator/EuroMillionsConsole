using EuroMillionsConsole.Interfaces;

namespace EuroMillionsConsole.Utils;

/// <summary>
/// Implémentation concrète de la génération de nombres aléatoires uniques dans une plage donnée
/// </summary>
internal sealed class RandomNumberProvider : IRandomNumberProvider
{
    public IEnumerable<int> PickUniqueNumbers(int minInclusive, int maxInclusive, int count)
    {
        if (maxInclusive - minInclusive + 1 < count)
            throw new ArgumentException("Pas assez de valeurs possibles pour générer des nombres uniques."); // Par exemple : 10 nombres uniques entre 1 et 5

        List<int> allPossible = Enumerable.Range(minInclusive, maxInclusive - minInclusive + 1).ToList();
        List<int> result = new(count);

        while (result.Count < count)
        {
            int index = Random.Shared.Next(allPossible.Count);
            result.Add(allPossible[index]);
            allPossible.RemoveAt(index); // évite les doublons
        }

        return result;
    }
}
