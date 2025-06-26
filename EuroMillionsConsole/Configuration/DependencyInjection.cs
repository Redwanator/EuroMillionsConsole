using EuroMillionsConsole.Engine;
using EuroMillionsConsole.Grids;
using EuroMillionsConsole.Interaction;
using EuroMillionsConsole.Payment;
using EuroMillionsConsole.Pricing;
using EuroMillionsConsole.Randomization;
using Microsoft.Extensions.DependencyInjection;

namespace EuroMillionsConsole.Configuration;

internal static class DependencyInjection
{
    /*
        [EuroMillionsEngine]    --uses-->   [IUserInteraction]    --> [ConsoleUserInteraction]
                                --uses-->   [IGridGenerator]      --> [GridGenerator]             --> [IRandomNumberProvider]     --> [RandomNumberProvider]
                                --uses-->   [IPriceCalculator]    --> [PriceCalculator]
                                --uses-->   [ICashRegister]       --> [CashRegister]              --> [IUserInteraction]
                                --uses-->   [IGridDisplayService] --> [GridDisplayService]        --> [IUserInteraction]
     */

    internal static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Singleton : services réutilisables, sans état propre ou dépendant uniquement des paramètres
        services.AddSingleton<IUserInteraction, ConsoleUserInteraction>();       // Interaction console         — Singleton car utilisé globalement pour interagir avec l'utilisateur
        services.AddSingleton<IPriceCalculator, PriceCalculator>();              // Calcul tarifaire            — Singleton car calcule uniquement à partir des données fournies
        services.AddSingleton<IRandomNumberProvider, RandomNumberProvider>();    // Génération aléatoire        — Singleton car autonome, ne nécessite pas de recréation
        services.AddSingleton<IGridDisplayService, GridDisplayService>();        // Affichage des grilles       — Singleton car affiche sans conserver d'état

        // Transient : services créés à chaque appel car ils dépendent d’un contexte ou doivent rester isolés
        services.AddTransient<EuroMillionsEngine>();                             // Moteur principal du jeu     — Transient car moteur lancé/rejoué à chaque session, ne garde pas d’état global
        services.AddTransient<ICashRegister, CashRegister>();                    // Gestion du paiement         — Transient car chaque interaction de paiement est contextuelle
        services.AddTransient<IGridGenerator, GridGenerator>();                  // Générateur de grilles       — Transient car chaque grille doit être unique et isolée

        return services;
    }
}
