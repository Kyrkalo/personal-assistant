namespace PersonalAssistant.Core.Abstractions;

public interface ICommandHandler
{
    bool CanHandle(string input);

    Task<string> HandleAsync(string input, CancellationToken cancellationToken = default);
}
