using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Isu.Services;
using Isu.Tools;
using IsuExtra.Services;

namespace IsuExtra
{
    public class IsuExtraService : IIsuExtraService
    {
        public IsuExtraService() { }
        public List<Teacher> Teacher { get; } = new List<Teacher>();
        public List<GroupSchedule> GroupSchedules { get; } = new List<GroupSchedule>();
        public List<OgnpGroupSchedule> OgnpGroupSchedules { get; } = new List<OgnpGroupSchedule>();
        public List<MegafacultyDiscipline> Disciplines { get; } = new List<MegafacultyDiscipline>();
        public IsuServices IsuServices { get; } = new IsuServices(20);
        public Student AddStudent(Group group, string studentName)
        {
            return IsuServices.AddStudent(group, studentName);
        }

        public Group AddGroup(string name)
        {
            return IsuServices.AddGroup(name);
        }

        public OgnpGroup AddOgnpGroup(string name, MegafacultyDiscipline megafaculty)
        {
            OgnpGroup group = new OgnpGroup(name);
            foreach (var dc in Disciplines)
            {
                if (dc.Letter == megafaculty.Letter)
                {
                    dc.OgnpGroups.Add(group);
                }
            }

            return group;
        }

        public Teacher AddTeacher(string name)
        {
            var teacher = new Teacher(name);
            Teacher.Add(teacher);
            return teacher;
        }

        public void AddGroupSchedule(Group group, string name, Teacher teacher, string classroom, int numberPair, DayOfWeek day)
        {
            Pair pair = new Pair(name, teacher, classroom, numberPair);
            DaySchedule daySchedule = new DaySchedule(pair, day);
            GroupSchedule groupSchedule = new GroupSchedule(group, daySchedule);
            GroupSchedules.Add(groupSchedule);
        }

        public void AddOgnpGroupSchedule(MegafacultyDiscipline megafaculty, OgnpGroup group, string name, Teacher teacher, string classroom, int numberPair, DayOfWeek day)
        {
            foreach (MegafacultyDiscipline faculty in Disciplines)
            {
                if (faculty.Name == megafaculty.Name)
                {
                    foreach (OgnpGroup gr in faculty.OgnpGroups.ToList())
                    {
                        if (group.Name == group.Name)
                        {
                            Pair pair = new Pair(name, teacher, classroom, numberPair);
                            DaySchedule daySchedule = new DaySchedule(pair, day);
                            OgnpGroupSchedule ognpGroupSchedule = new OgnpGroupSchedule(group, daySchedule);
                            OgnpGroupSchedules.Add(ognpGroupSchedule);
                        }
                    }
                }
            }
        }

        public MegafacultyDiscipline AddDiscipline(string faculty, string letter, string name)
        {
            var discipline = new MegafacultyDiscipline(faculty, letter, name);
            Disciplines.Add(discipline);
            return discipline;
        }

        public void AddStudentToOGNPGroup(Student student, OgnpGroup ognpGroup, Group group)
        {
            string firstLetter = group.Name.Substring(0, 1);
            foreach (var gr in GroupSchedules)
            {
                foreach (var ogn in OgnpGroupSchedules)
                {
                    if ((gr.DaySchedules.DayOfWeek != ogn.DaySchedules.DayOfWeek) ||
                        (gr.DaySchedules.Pair.NumberPair != ogn.DaySchedules.Pair.NumberPair))
                    {
                        ognpGroup.GetOGNPStudent().Add(student);
                    }
                }
            }
        }

        public void DeleteStudentFromOGNPGroup(Student student, OgnpGroup group, MegafacultyDiscipline megafaculty)
        {
            foreach (var dc in Disciplines)
            {
                if (dc.Name == megafaculty.Name)
                {
                    foreach (OgnpGroup gr in dc.OgnpGroups)
                    {
                        if (group.Name == gr.Name)
                        {
                            foreach (Student st in gr.GetOGNPStudent().ToList())
                            {
                                if (st.Id == student.Id)
                                {
                                    group.GetOGNPStudent().Remove(st);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}