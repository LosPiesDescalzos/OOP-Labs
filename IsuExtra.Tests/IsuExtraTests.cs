using System;
using System.Linq;
using IsuExtra;
using Isu.Services;
using Isu.Tools;
using NUnit.Framework;

namespace IsuExtra.Tests
{
    public class Tests
    {
            private IsuExtraService _isuExtraService;

            [SetUp]
            public void Setup()
            {
                _isuExtraService = new IsuExtraService();
            }

            [Test]
            public void AddDiscipline()
            {
                MegafacultyDiscipline discipline = _isuExtraService.AddDiscipline("FITIP", "M", "Programming");
                Assert.Contains(discipline, _isuExtraService.Discipline.ToList());
            }
            
            [Test]
            public void AddTeacher()
            {
                Teacher teacher1 = _isuExtraService.AddTeacher("Povyshev");
                Assert.Contains(teacher1, _isuExtraService.Teacher.ToList());
            }
            
            [Test]
            public void AddPair()
            {
                Teacher teacher1 = _isuExtraService.AddTeacher("Mayatin");
                Assert.Contains(teacher1, _isuExtraService.Teacher.ToList());
                Pair pair1 = _isuExtraService.AddPair("OS", teacher1, "312", 1);
                Assert.Contains(pair1, _isuExtraService.Pairs.ToList());
            }
            
            [Test]
            public void AddStudentToGroup()
            {
                Group gr = _isuExtraService.AddGroup("M3218");
                Student st = _isuExtraService.AddStudent(gr, "Max");
            }
            
            [Test]
            public void AddGroupSchedule()
            {
                Group gr = _isuExtraService.AddGroup("M3203");
                Student st = _isuExtraService.IsuServices.AddStudent(gr, "Dima");
                Teacher teacher1 = _isuExtraService.AddTeacher("Mayatin");
                Pair pair1 = _isuExtraService.AddPair("OS", teacher1, "312", 1);
                DayOfWeek day = DayOfWeek.Monday;
                GroupSchedule groupSchedule1 = _isuExtraService.AddGroupSchedule(pair1, day, gr);
            }

            [Test]
            public void AddDisciplineSchedule()
            {
                MegafacultyDiscipline discipline = _isuExtraService.AddDiscipline("ORGN", "R", "Robots");
                Teacher teacher1 = _isuExtraService.AddTeacher("Malyshev");
                DayOfWeek day = DayOfWeek.Monday;
                DisciplineSchedule disciplineSchedule =
                    _isuExtraService.AddDisciplineSchedule(discipline, "426", 2, teacher1, day);
            }
            
            [Test]
            public void AddOGNPGroup()
            {
                OGNPgroup gr1 = _isuExtraService.AddOGNPGroup("group1");
            }

           [Test]
            public void AddStudentToOGNPGroup()
            {
                OGNPgroup gr2 = _isuExtraService.AddOGNPGroup("group2");
                
                MegafacultyDiscipline discipline = _isuExtraService.AddDiscipline("ORGN", "R", "Robots");
                Teacher teacher1 = _isuExtraService.AddTeacher("Malyshev");
                DayOfWeek day = DayOfWeek.Monday;
                DisciplineSchedule disciplineSchedule =
                    _isuExtraService.AddDisciplineSchedule(discipline, "426", 2, teacher1, day);
                
                Group gr = _isuExtraService.AddGroup("M3203");
                Student st = _isuExtraService.AddStudent(gr, "Dima");
                Teacher teacher2 = _isuExtraService.AddTeacher("Mayatin");
                Pair pair1 = _isuExtraService.AddPair("OS", teacher2, "312", 4);
                DayOfWeek day2 = DayOfWeek.Thursday;
                GroupSchedule groupSchedule1 = _isuExtraService.AddGroupSchedule(pair1, day2, gr);
               
                _isuExtraService.AddStudentToOGNPGroup(groupSchedule1, disciplineSchedule, st, gr2, gr);
                Assert.IsNotEmpty(gr2.OGNPStudents);
                Assert.Contains(st, gr2.OGNPStudents);

               _isuExtraService.DeleteStudentFromOGNPGroup(st, gr2);
                Assert.IsEmpty(gr2.OGNPStudents);
            }
    }
}