using System.Collections.Generic;
using Isu.Services;

namespace IsuExtra
{
    public class Pair
    {
        public Pair(string name, Teacher teacher, string classroom, int numberPair)
        {
            PairName = name;
            Teacher = teacher;
            Classroom = classroom;
            NumberPair = numberPair;
        }

        public string Classroom { get; }
        public string PairName { get; }
        public Teacher Teacher { get; }
        public int NumberPair { get; }
    }
}