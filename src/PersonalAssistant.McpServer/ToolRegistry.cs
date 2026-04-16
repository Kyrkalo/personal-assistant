using PersonalAssistant.Core.Abstractions;

namespace PersonalAssistant.McpServer;

/// <summary>
/// Registers ITool implementations as MCP tools.
/// Wire up ModelContextProtocol package here when MCP phase begins.
/// Each ITool.Name maps to an MCP tool name, ITool.Description maps to the MCP tool description.
/// </summary>
public class ToolRegistry
{
    private readonly IEnumerable<ITool> _tools;

    public ToolRegistry(IEnumerable<ITool> tools)
    {
        _tools = tools;
    }

    public ITool? Find(string name) =>
        _tools.FirstOrDefault(t => t.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

    public IEnumerable<(string Name, string Description)> ListTools() =>
        _tools.Select(t => (t.Name, t.Description));
}
