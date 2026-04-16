using PersonalAssistant.Core.Abstractions;
using PersonalAssistant.Core.Models;

namespace PersonalAssistant.Infrastructure.Calendar;

public class FakeCalendarService : ICalendarService
{
    public Task<IReadOnlyList<CalendarEventItem>> GetEventsForTodayAsync(CancellationToken cancellationToken = default)
    {
        var today = DateTime.Today;

        IReadOnlyList<CalendarEventItem> events = new List<CalendarEventItem>
        {
            new() { Title = "Team standup",    Start = today.AddHours(9),  End = today.AddHours(9.5) },
            new() { Title = "Doctor appointment", Start = today.AddHours(14), End = today.AddHours(15), Location = "City Clinic" }
        };

        return Task.FromResult(events);
    }
}
