using PersonalAssistant.Core.Abstractions;
using PersonalAssistant.Core.Models;

namespace PersonalAssistant.Infrastructure.AI;

/// <summary>
/// Calls the Anthropic Claude API.
/// Requires ANTHROPIC_API_KEY in environment or appsettings.json.
/// </summary>
public class ClaudeService : IClaudeService
{
    // TODO: inject HttpClient + IOptions<ClaudeOptions>
    public Task<string> ChatAsync(string prompt, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<string> ChatWithImageAsync(string prompt, string base64Image, string mediaType = "image/jpeg", CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<ToolCallResult> ChatWithToolsAsync(string prompt, IEnumerable<ToolDefinition> tools, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
