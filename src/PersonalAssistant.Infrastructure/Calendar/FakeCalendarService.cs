using PersonalAssistant.Core.Abstractions;
using PersonalAssistant.Core.Models;

namespace PersonalAssistant.Infrastructure.Calendar;

public class FakeCalendarService : ICalendarService
{
    private readonly List<CalendarEventItem> _store =
    [
        new() { Title = "Team standup",       Start = DateTime.Today.AddHours(9),  End = DateTime.Today.AddHours(9.5) },
        new() { Title = "Doctor appointment", Start = DateTime.Today.AddHours(14), End = DateTime.Today.AddHours(15), Location = "City Clinic" }
    ];

    public Task<IReadOnlyList<CalendarEventItem>> GetEventsForTodayAsync(CancellationToken cancellationToken = default)
    {
        var today = DateTime.Today;
        IReadOnlyList<CalendarEventItem> events = _store
            .Where(e => e.Start.Date == today)
            .ToList();

        return Task.FromResult(events);
    }

    public Task<CalendarEventItem> CreateEventAsync(CalendarEventItem item, CancellationToken cancellationToken = default)
    {
        _store.Add(item);
        Console.WriteLine($"[Fake] Event created: {item.Title} at {item.Start:g}");
        return Task.FromResult(item);
    }
}
