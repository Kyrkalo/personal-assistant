using PersonalAssistant.Core.Abstractions;

namespace PersonalAssistant.Application.Services;

internal class AssistantService : IAssistantService
{
    private readonly IEnumerable<ICommandHandler> _handlers;

    public AssistantService(IEnumerable<ICommandHandler> handlers)
    {
        _handlers = handlers;
    }

    public async Task<string> HandleAsync(string input, CancellationToken cancellationToken = default)
    {
        var normalized = input?.Trim() ?? string.Empty;

        if (string.IsNullOrWhiteSpace(normalized))
            return "Please enter a command.";

        foreach (var handler in _handlers)
        {
            if (handler.CanHandle(normalized))
                return await handler.HandleAsync(normalized, cancellationToken);
        }

        return "Unknown command. Type 'help' to see available commands.";
    }
}
