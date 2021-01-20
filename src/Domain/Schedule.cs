using System;

namespace bounty.Domain
{
    public class Schedule
    {
        public static readonly Schedule OnceAMonth = new Schedule(DateTime.Today, TimeSpan.FromDays(31));
        public DateTime StartDate { get; }
        public TimeSpan Interval { get; }

        Schedule(DateTime startDate, TimeSpan interval)
        {
            StartDate = startDate;
            Interval = interval;
        }
    }
}
