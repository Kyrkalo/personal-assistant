using PersonalAssistant.Core.Abstractions;

namespace PersonalAssistant.Infrastructure.Auth;

public class FakeAuthService : IAuthService
{
    public Task<string> LoginAsync(string provider, CancellationToken cancellationToken = default) =>
        Task.FromResult($"[Fake] Logged in with {provider}.");
}
