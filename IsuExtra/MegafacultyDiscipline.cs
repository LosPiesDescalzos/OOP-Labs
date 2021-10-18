using System.Collections.Generic;
using Isu.Services;

namespace IsuExtra
{
    public class MegafacultyDiscipline
    {
        public MegafacultyDiscipline(string faculty, string letter, string discipline)
        {
            Name = faculty;
            Letter = letter;
            Discipline = discipline;
        }

        public string Name { get; }
        public string Letter { get; }
        public string Discipline { get; }
    }
}