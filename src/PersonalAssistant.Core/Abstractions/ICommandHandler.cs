namespace PersonalAssistant.Core.Abstractions;

public interface ICommandHandler
{
    (string, bool) CanExecute(string input);

    Task<string> ExecuteAsync(string input, CancellationToken cancellationToken = default);
}
