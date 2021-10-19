using System;
using System.Collections.Generic;
using Isu.Services;

namespace IsuExtra
{
    public class GroupSchedule
    {
        public GroupSchedule(Group group, DaySchedule daySchedule)
        {
            Group = group;
            DaySchedules = daySchedule;
        }

        public Group Group { get; }

        public DaySchedule DaySchedules { get; }
    }
}