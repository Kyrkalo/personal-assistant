using PersonalAssistant.Core.Models;

namespace PersonalAssistant.Core.Abstractions;

public interface ICalendarService
{
    Task<IReadOnlyList<CalendarEventItem>> GetEventsForTodayAsync(CancellationToken cancellationToken = default);
}
