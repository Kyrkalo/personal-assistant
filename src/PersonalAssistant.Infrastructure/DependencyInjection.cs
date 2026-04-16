using Microsoft.Extensions.DependencyInjection;
using PersonalAssistant.Core.Abstractions;
using PersonalAssistant.Infrastructure.Auth;
using PersonalAssistant.Infrastructure.Calendar;

namespace PersonalAssistant.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // Swap Fake* for real implementations when ready
        services.AddScoped<ICalendarService, FakeCalendarService>();
        services.AddScoped<IAuthService, FakeAuthService>();

        return services;
    }
}
