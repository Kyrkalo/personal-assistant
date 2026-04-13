namespace PersonalAssistant.Core.Abstractions;

public interface IAssistantService
{
    Task<string> HandleAsync(string input, CancellationToken cancellationToken = default);
}
