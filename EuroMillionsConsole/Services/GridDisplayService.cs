using EuroMillionsConsole.Interfaces;
using EuroMillionsConsole.Models;

namespace EuroMillionsConsole.Services;

/// <summary>
/// Implémentation concrète de l'affichage des grilles générées
/// </summary>
internal sealed class GridDisplayService(IUserInteraction ui) : IGridDisplayService
{
    private readonly IUserInteraction _ui = ui;

    public void Display(IEnumerable<EuroMillionsGrid> grids)
    {
        int i = 1;
        foreach (EuroMillionsGrid grid in grids)
        {
            _ui.PrintLine($"Grille {i++:00} : {grid}");
        }
    }
}
