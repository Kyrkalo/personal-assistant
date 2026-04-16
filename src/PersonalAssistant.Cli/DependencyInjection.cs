using Microsoft.Extensions.DependencyInjection;

namespace PersonalAssistant.Cli;

public static class DependencyInjection
{
    public static IServiceCollection AddCli(this IServiceCollection services)
    {
        services.AddScoped<CommandLoop>();
        return services;
    }
}
