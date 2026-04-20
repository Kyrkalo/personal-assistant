using System.ComponentModel;
using ModelContextProtocol.Server;
using PersonalAssistant.Application.Tools;

namespace PersonalAssistant.McpServer;

/// <summary>
/// Exposes Application tools as MCP tools.
/// Claude (or any MCP client) can call these autonomously.
/// </summary>
[McpServerToolType]
public class CalendarMcpTools
{
    private readonly GetEventsTool _getEvents;
    private readonly CreateEventTool _createEvent;
    private readonly ExtractEventFromImageTool _extractEvent;
    private readonly SyncCalendarsTool _syncCalendars;

    public CalendarMcpTools(
        GetEventsTool getEvents,
        CreateEventTool createEvent,
        ExtractEventFromImageTool extractEvent,
        SyncCalendarsTool syncCalendars)
    {
        _getEvents     = getEvents;
        _createEvent   = createEvent;
        _extractEvent  = extractEvent;
        _syncCalendars = syncCalendars;
    }

    [McpServerTool(Name = "get_events")]
    [Description("Returns calendar events for today.")]
    public Task<string> GetEventsAsync(CancellationToken cancellationToken) =>
        _getEvents.ExecuteAsync([], cancellationToken);

    [McpServerTool(Name = "create_event")]
    [Description("Creates a new calendar event. Required: title, start. Optional: end, location.")]
    public Task<string> CreateEventAsync(
        [Description("Event title")] string title,
        [Description("Start date and time, e.g. 2026-04-20 15:00")] string start,
        [Description("End date and time. Defaults to 1 hour after start.")] string? end,
        [Description("Location or meeting link")] string? location,
        CancellationToken cancellationToken)
    {
        var parameters = new Dictionary<string, string> { ["title"] = title, ["start"] = start };
        if (end      != null) parameters["end"]      = end;
        if (location != null) parameters["location"] = location;

        return _createEvent.ExecuteAsync(parameters, cancellationToken);
    }

    [McpServerTool(Name = "extract_event_from_image")]
    [Description("Reads a document or appointment letter photo and extracts event details. Pass a base64-encoded image.")]
    public Task<string> ExtractEventFromImageAsync(
        [Description("Base64-encoded image of the document")] string base64Image,
        CancellationToken cancellationToken) =>
        _extractEvent.ExecuteAsync(new Dictionary<string, string> { ["image"] = base64Image }, cancellationToken);

    [McpServerTool(Name = "sync_calendars")]
    [Description("Synchronises events between connected calendar providers.")]
    public Task<string> SyncCalendarsAsync(CancellationToken cancellationToken) =>
        _syncCalendars.ExecuteAsync([], cancellationToken);
}
