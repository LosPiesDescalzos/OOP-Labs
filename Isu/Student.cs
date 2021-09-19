using System;

namespace Isu.Services
{
    public class Student
    {
        private int _id;
        public Student(string name)
        {
            Name = name;
            Id = ++_id;
        }

        public string Name { get; }
        public int Id { get; }
    }
}