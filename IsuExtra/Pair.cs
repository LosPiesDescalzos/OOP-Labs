using System.Collections.Generic;
using Isu.Services;

namespace IsuExtra
{
    public class Pair
    {
        private int _id = 0;
        public Pair(string name, Teacher teacher, string classroom, int numberPair)
        {
            PairName = name;
            Teacher = teacher;
            Classroom = classroom;
            NumberPair = numberPair;
            Id = _id++;
        }

        public string Classroom { get; }
        public int Id { get; }
        public string PairName { get; }
        public Teacher Teacher { get; }
        public int NumberPair { get; }
    }
}