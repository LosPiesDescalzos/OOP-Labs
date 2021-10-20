using System;
using System.Collections.Generic;
using Isu.Services;
using Isu.Tools;

namespace IsuExtra.Services
{
    public interface IIsuExtraService
    {
        Student AddStudent(Group group, string studentName);
        Group AddGroup(string name);
        OgnpGroup AddOgnpGroup(string name, MegafacultyDiscipline megafaculty);
        Teacher AddTeacher(string name);
        void AddGroupSchedule(Group group, string name, Teacher teacher, string classroom, int numberPair, DayOfWeek day);
        void AddOgnpGroupSchedule(MegafacultyDiscipline megafaculty, OgnpGroup group, string name, Teacher teacher, string classroom, int numberPair, DayOfWeek day);
        MegafacultyDiscipline AddDiscipline(string faculty, string letter, string name);
        void AddStudentToOGNPGroup(Student student, OgnpGroup ognpGroup, Group group);
        void DeleteStudentFromOGNPGroup(Student student, OgnpGroup group, MegafacultyDiscipline megafaculty);
    }
}