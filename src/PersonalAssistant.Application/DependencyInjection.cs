using Microsoft.Extensions.DependencyInjection;
using PersonalAssistant.Application.Commands;
using PersonalAssistant.Application.Services;
using PersonalAssistant.Application.Tools;
using PersonalAssistant.Core.Abstractions;

namespace PersonalAssistant.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAssistantService, AssistantService>();
        services.AddScoped<IntentResolver>();

        // Tools (MCP-ready business logic)
        services.AddScoped<GetEventsTool>();
        services.AddScoped<CreateEventTool>();
        services.AddScoped<ExtractEventFromImageTool>();
        services.AddScoped<SyncCalendarsTool>();

        // CLI command handlers (delegate to Tools)
        services.AddScoped<ICommandHandler, HelpCommandHandler>();
        services.AddScoped<ICommandHandler, TodayCommandHandler>();
        services.AddScoped<ICommandHandler, LoginCommandHandler>();

        return services;
    }
}
