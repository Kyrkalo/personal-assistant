namespace PersonalAssistant.Core.Models;

public class AssistantResponse
{
    public string Text { get; init; } = string.Empty;
    public bool IsError { get; init; }

    public static AssistantResponse Success(string text) => new() { Text = text };
    public static AssistantResponse Error(string message) => new() { Text = message, IsError = true };
}
