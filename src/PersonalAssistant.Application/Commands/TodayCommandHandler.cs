using PersonalAssistant.Application.Tools;
using PersonalAssistant.Core.Abstractions;

namespace PersonalAssistant.Application.Commands;

public class TodayCommandHandler : ICommandHandler
{
    private readonly GetEventsTool _getEvents;

    public TodayCommandHandler(GetEventsTool getEvents)
    {
        _getEvents = getEvents;
    }

    public bool CanHandle(string input) =>
        input.Equals("today", StringComparison.OrdinalIgnoreCase);

    public Task<string> HandleAsync(string input, CancellationToken cancellationToken = default) =>
        _getEvents.ExecuteAsync([], cancellationToken);
}
