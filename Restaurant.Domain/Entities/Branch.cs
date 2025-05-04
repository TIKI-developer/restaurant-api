using Restaurant.Domain.ValueObjects;

namespace Restaurant.Domain.Entities
{
    public class Branch : Entity
    {
        public required string Name { get; set; }
        public required bool IsActive { get; set; }
        public required Address Address { get; set; }
        public required string PhoneNumber { get; set; }
        public required Schedule Schedule { get; set; }
        public required ulong AverageCookingTime { get; set; }
        public required Content Content { get; set; }
        public List<Order>? Orders { get; set; }

        public bool IsOpen => CalculateIsOpen();

        private bool CalculateIsOpen()
        {
            if (!IsActive || Schedule == null)
                return false;

            var tz = TimeZoneInfo.FindSystemTimeZoneById("Europe/Moscow");
            var now = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, tz);

            var today = now.DayOfWeek;
            var timeNow = TimeOnly.FromDateTime(now);

            var todaySchedule = Schedule.Days.FirstOrDefault(d => d.Day == today);

            if (todaySchedule == null || todaySchedule.IsClosed)
                return false;

            return timeNow >= todaySchedule.OpenTime && timeNow <= todaySchedule.CloseTime;
        }

    }
}
