using System.Collections.Generic;
using Isu.Services;

namespace IsuExtra
{
    public class Teacher
    {
        private static int _id = 0;
        public Teacher(string name)
        {
            Name = name;
            Id = ++_id;
        }

        public int Id { get; }
        public string Name { get; }
    }
}