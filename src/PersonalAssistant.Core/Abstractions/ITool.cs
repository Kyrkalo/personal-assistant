namespace PersonalAssistant.Core.Abstractions;

/// <summary>
/// Represents a discrete action the assistant can perform.
/// Each tool maps directly to an MCP tool when the McpServer is active.
/// </summary>
public interface ITool
{
    string Name { get; }
    string Description { get; }

    Task<string> ExecuteAsync(Dictionary<string, string> parameters, CancellationToken cancellationToken = default);
}
