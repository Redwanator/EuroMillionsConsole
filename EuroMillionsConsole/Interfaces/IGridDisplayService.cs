using EuroMillionsConsole.Models;

namespace EuroMillionsConsole.Interfaces;

/// <summary>
/// Interface de service pour l'affichage des grilles générées
/// </summary>
internal interface IGridDisplayService
{
    void Display(IEnumerable<EuroMillionsGrid> grids);
}
