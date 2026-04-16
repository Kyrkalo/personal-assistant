using PersonalAssistant.Core.Abstractions;

namespace PersonalAssistant.Application.Commands;

public class LoginCommandHandler : ICommandHandler
{
    private readonly IAuthService _auth;

    public LoginCommandHandler(IAuthService auth)
    {
        _auth = auth;
    }

    public bool CanHandle(string input) =>
        input.StartsWith("login", StringComparison.OrdinalIgnoreCase);

    public async Task<string> HandleAsync(string input, CancellationToken cancellationToken = default)
    {
        var provider = input.Replace("login", string.Empty).Trim();

        if (string.IsNullOrEmpty(provider))
            return "Usage: login google";

        var result = await _auth.LoginAsync(provider, cancellationToken);
        return result;
    }
}
