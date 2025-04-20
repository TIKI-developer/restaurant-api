namespace Restaurant.Domain.ValueObjects
{
    public class Schedule
    {
        public List<DailySchedule> Days { get; private set; } = [];

        private Schedule() { }

        public Schedule(IEnumerable<DailySchedule> days)
        {
            if (days == null) throw new ArgumentNullException(nameof(days));

            var dayList = days.ToList();
            if (dayList.Count != 7)
                throw new ArgumentException("Schedule must contain 7 days (Monday to Sunday).");

            Days = days.ToList();
        }
    }

    public class DailySchedule
    {
        public DayOfWeek Day { get; }
        public TimeOnly OpenTime { get; }
        public TimeOnly CloseTime { get; }
        public bool IsClosed { get; }

        private DailySchedule() { }

        public DailySchedule(DayOfWeek day, TimeOnly openTime, TimeOnly closeTime, bool isClosed = false)
        {
            if (!isClosed && openTime >= closeTime)
                throw new ArgumentException("Open time must be earlier than close time.");

            Day = day;
            OpenTime = openTime;
            CloseTime = closeTime;
            IsClosed = isClosed;
        }
    }
}
