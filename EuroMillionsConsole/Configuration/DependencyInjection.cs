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
    internal static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddSingleton<IUserInteraction, ConsoleUserInteraction>();
        services.AddSingleton<IRandomNumberProvider, RandomNumberProvider>();
        services.AddSingleton<IGridGenerator, GridGenerator>();
        services.AddSingleton<IPriceCalculator, PriceCalculator>();
        services.AddSingleton<ICashRegister, CashRegister>();
        services.AddSingleton<IGridDisplayService, GridDisplayService>();
        services.AddSingleton<EuroMillionsEngine>();

        return services;
    }
}
