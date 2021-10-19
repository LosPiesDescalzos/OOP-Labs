using System;
using System.Collections.Generic;
using Isu.Services;
using Isu.Tools;

namespace IsuExtra.Services
{
    public interface IIsuExtraService
    {
        public Student AddStudent(Group group, string studentName);
        public Group AddGroup(string name);
        public OgnpGroup AddOgnpGroup(string name, MegafacultyDiscipline megafaculty);
        public Teacher AddTeacher(string name);
        public void AddGroupSchedule(Group group, string name, Teacher teacher, string classroom, int numberPair, DayOfWeek day);

        public void AddOgnpGroupSchedule(MegafacultyDiscipline megafaculty, OgnpGroup group, string name, Teacher teacher, string classroom, int numberPair, DayOfWeek day);

        public MegafacultyDiscipline AddDiscipline(string faculty, string letter, string name);
        public void AddStudentToOGNPGroup(Student student, OgnpGroup ognpGroup, Group group);
        public void DeleteStudentFromOGNPGroup(Student student, OgnpGroup group, MegafacultyDiscipline megafaculty);
    }
}