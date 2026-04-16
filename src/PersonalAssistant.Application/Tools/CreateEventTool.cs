using PersonalAssistant.Core.Abstractions;

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

    public Task<string> ExecuteAsync(Dictionary<string, string> parameters, CancellationToken cancellationToken = default)
    {
        // TODO: implement once ICalendarService.CreateEventAsync is added
        throw new NotImplementedException();
    }
}
