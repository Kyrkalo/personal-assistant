using PersonalAssistant.Core.Abstractions;
using PersonalAssistant.Core.Models;

namespace PersonalAssistant.Infrastructure.AI;

/// <summary>
/// Fake Claude service for development. Returns hardcoded JSON so the flow
/// can be tested end-to-end without an Anthropic API key.
/// Swap for ClaudeService once ANTHROPIC_API_KEY is configured.
/// </summary>
public class FakeClaudeService : IClaudeService
{
    public Task<string> ChatAsync(string prompt, CancellationToken cancellationToken = default) =>
        Task.FromResult("[Fake] Claude response.");

    public Task<string> ChatWithImageAsync(string prompt, string base64Image, string mediaType = "image/jpeg", CancellationToken cancellationToken = default)
    {
        var json =
            """
            {
              "title": "Dentist appointment",
              "start": "2026-04-25 10:00",
              "end":   "2026-04-25 11:00",
              "location": "City Dental Clinic"
            }
            """;

        return Task.FromResult(json);
    }

    public Task<ToolCallResult> ChatWithToolsAsync(string prompt, IEnumerable<ToolDefinition> tools, CancellationToken cancellationToken = default) =>
        Task.FromResult(ToolCallResult.FromText("[Fake] Claude tool response."));
}
