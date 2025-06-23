namespace EuroMillionsConsole.Interfaces;
internal interface IRandomNumberProvider
{
    IEnumerable<int> PickUniqueNumbers(int minInclusive, int maxInclusive, int count);
}
