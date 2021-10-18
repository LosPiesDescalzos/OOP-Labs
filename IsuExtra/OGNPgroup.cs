using System.Collections.Generic;
using Isu.Services;

namespace IsuExtra
{
    public class OGNPgroup
    {
        public OGNPgroup(string name)
        {
           Name = name;
        }

        public string Name { get; }
        public List<Student> OGNPStudents { get; } = new List<Student>();
    }
}