using System;

namespace UnityBase
{
    /// <summary>
    /// Represents a task that you can track time for
    /// </summary>
    public class TimeTrackerTask
    {
        public string TaskName { get; set; }
        public TimeSpan GetTimeSpendOnTask()
        {
            return new TimeSpan(TimeSpendOnTask);
        }

        public long TimeSpendOnTask { get; set; } = new TimeSpan(0, 0, 0).Ticks;
    }
}
