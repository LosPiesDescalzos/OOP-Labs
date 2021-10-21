using System;
using System.Collections.Generic;
using Isu.Services;

namespace IsuExtra
{
    public class DisciplineSchedule
    {
        public DisciplineSchedule(MegafacultyDiscipline discipline, string classRoom, int numberPair, Teacher teacher, DayOfWeek day)
        {
            Discipline = discipline;
            ClassRoom = classRoom;
            NumberPair = numberPair;
            Teacher = teacher;
            Day = day;
        }

        public string Name { get; }
        public string ClassRoom { get; }
        public int NumberPair { get; }
        public Teacher Teacher { get; }

        public MegafacultyDiscipline Discipline { get; set; }
        public DayOfWeek Day { get; }
    }
}