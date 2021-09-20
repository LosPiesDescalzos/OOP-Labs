using System;
using System.Collections.Generic;

namespace Isu.Services
{
    public class Group
    {
        public Group(string groupName)
        {
            Name = groupName;
            int.TryParse(Name.Substring(2, 1), out int cr);
            Course = new CourseNumber(cr);
        }

        public List<Student> Students { get; } = new List<Student>();
        public string Name { get; }
        public CourseNumber Course { get; }
    }
}