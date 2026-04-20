using PersonalAssistant.Core.Abstractions;
using PersonalAssistant.Core.Models;

namespace PersonalAssistant.Application.Tools;

/// <summary>
/// Creates a calendar event from structured parameters.
/// Exposed as an MCP tool: "create_event"
/// </summary>
public class CreateEventTool : ITool
{
    private readonly ICalendarService _calendar;

    public CreateEventTool(ICalendarService calendar)
    {
        _calendar = calendar;
    }

    public string Name => "create_event";
    public string Description => "Creates a new calendar event. Required params: title, start, end. Optional: location.";

    public async Task<string> ExecuteAsync(Dictionary<string, string> parameters, CancellationToken cancellationToken = default)
    {
        if (!parameters.TryGetValue("title", out var title) || string.IsNullOrWhiteSpace(title))
            return "Error: 'title' is required.";

        if (!parameters.TryGetValue("start", out var startStr) || !DateTime.TryParse(startStr, out var start))
            return "Error: 'start' is required and must be a valid date/time.";

        if (!parameters.TryGetValue("end", out var endStr) || !DateTime.TryParse(endStr, out var end))
            end = start.AddHours(1);

        parameters.TryGetValue("location", out var location);

        var item = new CalendarEventItem
        {
            Title    = title,
            Start    = start,
            End      = end,
            Location = location
        };

        await _calendar.CreateEventAsync(item, cancellationToken);

        return $"Event '{title}' created for {start:g}.";
    }
}
