using PersonalAssistant.Core.Enums;

namespace PersonalAssistant.Application.Services;

/// <summary>
/// Resolves raw user input to an IntentType using keyword matching.
/// Replace the body of ResolveAsync with an Ollama call when ready.
/// </summary>
public class IntentResolver
{
    public Task<IntentType> ResolveAsync(string input, CancellationToken cancellationToken = default)
    {
        var normalized = input.ToLowerInvariant().Trim();

        var intent = normalized switch
        {
            "help" => IntentType.Help,
            "today" or "what do i have today" => IntentType.Today,
            var s when s.StartsWith("login") => IntentType.Login,
            var s when s.StartsWith("create event") || s.StartsWith("add event") => IntentType.CreateEvent,
            var s when s.StartsWith("sync") => IntentType.SyncCalendars,
            _ => IntentType.Unknown
        };

        return Task.FromResult(intent);
    }
}
