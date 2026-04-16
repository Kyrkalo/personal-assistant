using PersonalAssistant.Core.Abstractions;

namespace PersonalAssistant.Application.Commands;

public class HelpCommandHandler : ICommandHandler
{
    public bool CanHandle(string input) =>
        input.Equals("help", StringComparison.OrdinalIgnoreCase);

    public Task<string> HandleAsync(string input, CancellationToken cancellationToken = default)
    {
        var text =
"""
Available commands:
- help
- today
- login google
- exit
""";
        return Task.FromResult(text);
    }
}
