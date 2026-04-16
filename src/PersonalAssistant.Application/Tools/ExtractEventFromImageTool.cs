using PersonalAssistant.Core.Abstractions;

namespace PersonalAssistant.Application.Tools;

/// <summary>
/// Extracts calendar event details from a document photo using a vision LLM.
/// Exposed as an MCP tool: "extract_event_from_image"
/// </summary>
public class ExtractEventFromImageTool : ITool
{
    public string Name => "extract_event_from_image";
    public string Description => "Reads a document photo and extracts appointment details (title, date, time, location).";

    public Task<string> ExecuteAsync(Dictionary<string, string> parameters, CancellationToken cancellationToken = default)
    {
        // TODO: accept base64 image or file path, send to LLaVA via Ollama, parse response
        throw new NotImplementedException();
    }
}
