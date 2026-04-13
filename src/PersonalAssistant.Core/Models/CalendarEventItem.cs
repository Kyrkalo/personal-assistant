namespace PersonalAssistant.Core.Models;

public class CalendarEventItem
{
    public string Title { get; init; } = string.Empty;
    public DateTime Start { get; init; }
    public DateTime End { get; init; }
    public string? Location { get; init; }
}
