using EuroMillionsConsole.Interfaces;
using System.Security.Cryptography;

namespace EuroMillionsConsole.Utils;

internal sealed class RandomNumberProvider : IRandomNumberProvider
{
    private readonly RandomNumberGenerator _rng = RandomNumberGenerator.Create();

    public IEnumerable<int> PickUniqueNumbers(int minInclusive, int maxInclusive, int count)
    {
        if (maxInclusive - minInclusive + 1 < count)
            throw new ArgumentException("Pas assez de valeurs possibles pour générer des nombres uniques.");

        var allPossible = Enumerable.Range(minInclusive, maxInclusive - minInclusive + 1).ToList();
        var result = new List<int>(count);

        while (result.Count < count)
        {
            int index = GetRandomInt(0, allPossible.Count - 1);
            result.Add(allPossible[index]);
            allPossible.RemoveAt(index); // évite les doublons
        }

        return result;
    }

    private int GetRandomInt(int minInclusive, int maxInclusive)
    {
        // Génère un int aléatoire entre min et max inclus (uniformément réparti)
        byte[] bytes = new byte[4];
        _rng.GetBytes(bytes);
        int raw = BitConverter.ToInt32(bytes, 0) & int.MaxValue;
        return minInclusive + raw % (maxInclusive - minInclusive + 1);
    }
}
