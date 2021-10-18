using System;
using System.Collections.Generic;
using System.Linq;
using Isu.Services;
using Isu.Tools;

namespace IsuExtra
{
    public class IsuExtraService
    {
        public IsuExtraService() { }
        public List<Teacher> Teacher { get; } = new List<Teacher>();
        public List<GroupSchedule> GroupSchedule { get; } = new List<GroupSchedule>();
        public List<Pair> Pairs { get; } = new List<Pair>();
        public List<OGNPgroup> Groups { get; } = new List<OGNPgroup>();
        public List<DisciplineSchedule> OgnpSchedule { get; } = new List<DisciplineSchedule>();
        public List<MegafacultyDiscipline> Discipline { get; } = new List<MegafacultyDiscipline>();

        public IsuServices IsuServices { get; } = new IsuServices(20);

        public Student AddStudent(Group group, string studentName)
        {
            return IsuServices.AddStudent(group, studentName);
        }

        public Group AddGroup(string name)
        {
            return IsuServices.AddGroup(name);
        }

        public Teacher AddTeacher(string name)
        {
            var teacher = new Teacher(name);
            Teacher.Add(teacher);
            return teacher;
        }

        public Pair AddPair(string name, Teacher teacher, string classroom, int numberPair)
        {
            var pair = new Pair(name, teacher, classroom, numberPair);
            Pairs.Add(pair);
            return pair;
        }

        public GroupSchedule AddGroupSchedule(Pair pair, DayOfWeek day, Group group)
        {
            var groupSchedule = new GroupSchedule(group, pair, day);
            GroupSchedule.Add(groupSchedule);
            return groupSchedule;
        }

        public MegafacultyDiscipline AddDiscipline(string faculty, string letter, string name)
        {
            var discipline = new MegafacultyDiscipline(faculty, letter, name);
            Discipline.Add(discipline);
            return discipline;
        }

        public DisciplineSchedule AddDisciplineSchedule(MegafacultyDiscipline discipline, string classRoom, int numberPair, Teacher teacher, DayOfWeek day)
        {
            var ognpSchedule = new DisciplineSchedule(discipline, classRoom, numberPair, teacher, day);
            OgnpSchedule.Add(ognpSchedule);
            return ognpSchedule;
        }

        public OGNPgroup AddOGNPGroup(string name)
        {
            var group = new OGNPgroup(name);
            Groups.Add(group);
            return group;
        }

        public void AddStudentToOGNPGroup(GroupSchedule groupSchedule, DisciplineSchedule disciplineSchedule, Student student, OGNPgroup ognpGroup, Group group)
        {
            string firstLetter = group.Name.Substring(0, 1);
            if (((groupSchedule.Day != disciplineSchedule.Day) ||
                 (groupSchedule.Pair.NumberPair != disciplineSchedule.NumberPair)) &&
                (disciplineSchedule.Discipline.Letter != firstLetter))
            {
                ognpGroup.OGNPStudents.Add(student);
            }
        }

        public void DeleteStudentFromOGNPGroup(Student student, OGNPgroup group)
        {
            foreach (var gr in Groups)
            {
                if (group.Name == gr.Name)
                {
                    foreach (Student st in gr.OGNPStudents.ToList())
                    {
                        if (st.Id == student.Id)
                        {
                            group.OGNPStudents.Remove(st);
                        }
                    }
                }
            }
        }
    }
}