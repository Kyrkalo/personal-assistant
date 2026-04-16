using PersonalAssistant.Core.Abstractions;

namespace PersonalAssistant.Application.Tools;

/// <summary>
/// Syncs events between two calendar sources.
/// Exposed as an MCP tool: "sync_calendars"
/// </summary>
public class SyncCalendarsTool : ITool
{
    public string Name => "sync_calendars";
    public string Description => "Synchronises events between connected calendar providers.";

    public Task<string> ExecuteAsync(Dictionary<string, string> parameters, CancellationToken cancellationToken = default)
    {
        // TODO: implement calendar sync logic
        throw new NotImplementedException();
    }
}
