using System;
using System.Collections.Generic;
using System.Linq;
using Isu.Services;

namespace IsuExtra
{
    public class OgnpGroup
    {
        public OgnpGroup(string name)
        {
            Name = name;
        }

        public string Name { get; }
        private List<Student> OgnpStudents { get; } = new List<Student>();
        public List<Student> GetOGNPStudent()
        {
            return OgnpStudents;
        }
    }
}