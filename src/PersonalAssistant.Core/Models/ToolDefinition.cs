namespace PersonalAssistant.Core.Models;

/// <summary>
/// Describes a tool that Claude can choose to call.
/// Maps directly from ITool.Name and ITool.Description.
/// </summary>
public class ToolDefinition
{
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public Dictionary<string, string> Parameters { get; init; } = [];
}
