using PersonalAssistant.Core.Models;

namespace PersonalAssistant.Core.Abstractions;

/// <summary>
/// Abstraction over the Claude API (Anthropic).
/// Covers three use cases:
///   Phase 2 — natural language → intent (text)
///   Phase 3 — document photo → structured data (vision)
///   Phase 4 — autonomous tool calling (tools)
/// </summary>
public interface IClaudeService
{
    /// <summary>
    /// Sends a plain text message and returns Claude's reply.
    /// Used by IntentResolver (Phase 2).
    /// </summary>
    Task<string> ChatAsync(string prompt, CancellationToken cancellationToken = default);

    /// <summary>
    /// Sends a message with a base64-encoded image and returns Claude's reply.
    /// Used by ExtractEventFromImageTool (Phase 3).
    /// </summary>
    Task<string> ChatWithImageAsync(string prompt, string base64Image, string mediaType = "image/jpeg", CancellationToken cancellationToken = default);

    /// <summary>
    /// Sends a message with available tools. Claude decides which tool to call and returns
    /// the tool name + arguments. Used by McpServer (Phase 4).
    /// </summary>
    Task<ToolCallResult> ChatWithToolsAsync(string prompt, IEnumerable<ToolDefinition> tools, CancellationToken cancellationToken = default);
}
