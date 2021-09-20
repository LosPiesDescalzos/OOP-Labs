using System;
using System.Collections.Generic;
using Isu.Tools;

namespace Isu.Services
{
    public class Group
    {
        private const int LenghtGroup = 5;
        private const int MaxCourse = 4;
        private const int MinCourse = 1;
        public Group(string groupName)
        {
            Name = groupName;
            if (ChekGroup(Name))
            {
                string rightName = Name;
            }
        }

        public List<Student> Students { get; } = new List<Student>();
        public string Name { get; }
        public CourseNumber Course { get; }

        public bool ChekGroup(string groupName)
        {
            int count = groupName.Length;
            if (count != LenghtGroup)
            {
                throw new IsuException("Invalid name");
            }

            string firstLetters = groupName.Substring(0, 2);
            int.TryParse(groupName.Substring(2, 1), out int courseNumber);
            string subCourse = groupName.Substring(2, 1);
            string subLatters = groupName.Substring(3, 2);
            bool chekCourse = int.TryParse(subCourse, out int course);
            bool chekLastLetters = int.TryParse(subLatters, out int lastLetters);
            if (!chekCourse || !chekLastLetters)
            {
                throw new IsuException("Invalid name");
            }
            else if (firstLetters != "M3" || course > MaxCourse || course < MinCourse)
            {
                throw new IsuException("Invalid name");
            }

            return true;
        }
    }
}