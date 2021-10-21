using Isu.Services;

namespace IsuExtra
{
    public class OgnpGroupSchedule
    {
        public OgnpGroupSchedule(OgnpGroup group, DaySchedule daySchedule)
        {
            OgnpGroup = group;
            DaySchedules = daySchedule;
        }

        public OgnpGroup OgnpGroup { get; }

        public DaySchedule DaySchedules { get; }
    }
}