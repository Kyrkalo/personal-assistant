using PersonalAssistant.Core.Abstractions;

namespace PersonalAssistant.Application.Tools;

/// <summary>
/// Returns calendar events for a given date.
/// Exposed as an MCP tool: "get_events"
/// </summary>
public class GetEventsTool : ITool
{
    private readonly ICalendarService _calendar;

    public GetEventsTool(ICalendarService calendar)
    {
        _calendar = calendar;
    }

    public string Name => "get_events";
    public string Description => "Returns calendar events for today or a specified date.";

    public async Task<string> ExecuteAsync(Dictionary<string, string> parameters, CancellationToken cancellationToken = default)
    {
        var events = await _calendar.GetEventsForTodayAsync(cancellationToken);

        if (!events.Any())
            return "No events found.";

        return string.Join(Environment.NewLine, events.Select(e =>
            $"{e.Start:HH:mm} - {e.End:HH:mm}  {e.Title}" +
            (e.Location != null ? $" @ {e.Location}" : string.Empty)));
    }
}
