namespace PersonalAssistant.Core.Models;

/// <summary>
/// The result of a ChatWithToolsAsync call.
/// Either Claude calls a tool (ToolName is set) or responds with plain text.
/// </summary>
public class ToolCallResult
{
    public bool IsToolCall { get; init; }

    /// <summary>Tool name Claude chose to call. Null if plain text response.</summary>
    public string? ToolName { get; init; }

    /// <summary>Arguments Claude passed to the tool.</summary>
    public Dictionary<string, string> Arguments { get; init; } = [];

    /// <summary>Plain text response when Claude did not call a tool.</summary>
    public string? Text { get; init; }

    public static ToolCallResult FromTool(string toolName, Dictionary<string, string> arguments) =>
        new() { IsToolCall = true, ToolName = toolName, Arguments = arguments };

    public static ToolCallResult FromText(string text) =>
        new() { IsToolCall = false, Text = text };
}
