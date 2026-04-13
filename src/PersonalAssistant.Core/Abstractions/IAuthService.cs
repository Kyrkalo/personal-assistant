namespace PersonalAssistant.Core.Abstractions;

public interface IAuthService
{
    Task<string> LoginAsync(string provider, CancellationToken cancellationToken = default);
}
