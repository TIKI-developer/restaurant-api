using Restaurant.Domain.ValueObjects;

namespace Restaurant.WebApi.Models
{
    public class ScheduleDto
    {
        public required List<DailyScheduleDto> Days { get; set; }

        public static Schedule MapToSchedule(ScheduleDto schedule)
        {
            var dailySchedules = schedule.Days.Select(dto =>
                new DailySchedule(
                    dto.Day,
                    dto.OpenTime ?? TimeOnly.MinValue,
                    dto.CloseTime ?? TimeOnly.MinValue,
                    dto.IsClosed
                )
            );

            return new Schedule(dailySchedules);
        }
    }
    public class DailyScheduleDto
    {
        public DayOfWeek Day { get; set; }
        public TimeOnly? OpenTime { get; set; }
        public TimeOnly? CloseTime { get; set; }
        public bool IsClosed { get; set; }
    }
}
