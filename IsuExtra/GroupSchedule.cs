using System;
using System.Collections.Generic;
using Isu.Services;

namespace IsuExtra
{
    public class GroupSchedule
    {
        public GroupSchedule(Group group, Pair pair, DayOfWeek day)
        {
            Group = group;
            Pair = pair;
            Day = day;
        }

        public Group Group { get; }
        public Pair Pair { get; }
        public DayOfWeek Day { get; }
    }
}