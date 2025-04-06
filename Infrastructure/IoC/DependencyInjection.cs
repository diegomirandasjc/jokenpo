using Jokenpo.Application.UseCases;
using Jokenpo.Domain.Models;
using Jokenpo.Domain.Services;
using Jokenpo.Infrastructure.Config.Providers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Jokenpo.Infrastructure.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddJokenpoServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddSingleton<IConfiguration>(config);
        services.AddSingleton<IMoveConfigProvider, AppSettingsMoveConfigProvider>();

        // Carrega os movimentos de forma desacoplada
        services.AddScoped(provider =>
        {
            var moveLoader = provider.GetRequiredService<IMoveConfigProvider>();
            return new GameRuleService(moveLoader.LoadMoves());
        });

        services.AddScoped<PlayGameUseCase>();

        return services;
    }
}