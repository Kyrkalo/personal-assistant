using PersonalAssistant.Core.Abstractions;

namespace PersonalAssistant.Application.Tools;

/// <summary>
/// Extracts calendar event details from a document photo using a vision LLM.
/// Exposed as an MCP tool: "extract_event_from_image"
///
/// NOTE: When used via MCP, Claude reads the image itself and calls create_event directly.
/// This tool is used by the .NET API when processing uploads without a human in the loop.
/// </summary>
public class ExtractEventFromImageTool : ITool
{
    private readonly IClaudeService _claude;

    public ExtractEventFromImageTool(IClaudeService claude)
    {
        _claude = claude;
    }

    public string Name => "extract_event_from_image";
    public string Description => "Reads a document photo and extracts appointment details (title, date, time, location).";

    public async Task<string> ExecuteAsync(Dictionary<string, string> parameters, CancellationToken cancellationToken = default)
    {
        if (!parameters.TryGetValue("image", out var base64Image) || string.IsNullOrWhiteSpace(base64Image))
            return "Error: 'image' (base64) is required.";

        const string prompt =
            """
            Extract appointment details from this document image.
            Respond in JSON only:
            {
              "title": "...",
              "start": "YYYY-MM-DD HH:mm",
              "end":   "YYYY-MM-DD HH:mm",
              "location": "..."
            }
            If a field is not found, omit it.
            """;

        return await _claude.ChatWithImageAsync(prompt, base64Image, cancellationToken: cancellationToken);
    }
}
