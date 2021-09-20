using System;

namespace Isu.Services
{
    public class Student
    {
        private static int _id = 0;
        public Student(string name)
        {
            Name = name;
            Id = ++_id;
        }

        public string Name { get; }
        public int Id { get; }
    }
}