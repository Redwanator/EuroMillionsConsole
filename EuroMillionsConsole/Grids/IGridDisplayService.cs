﻿namespace EuroMillionsConsole.Grids;

/// <summary>
/// Interface de service pour l'affichage des grilles générées
/// </summary>
public interface IGridDisplayService
{
    void Display(IEnumerable<EuroMillionsGrid> grids);
}
