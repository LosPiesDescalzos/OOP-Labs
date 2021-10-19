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
                Assert.Contains(discipline, _isuExtraService.Disciplines.ToList());
            }
            
            [Test]
            public void AddTeacher()
            {
                Teacher teacher1 = _isuExtraService.AddTeacher("Povyshev");
                Assert.Contains(teacher1, _isuExtraService.Teacher.ToList());
            }

            [Test]
            public void AddStudentToGroup()
            {
                Group gr = _isuExtraService.AddGroup("M3218");
                Student st = _isuExtraService.AddStudent(gr, "Max");
                Assert.Contains(st, gr.Students);
            }
            
            [Test]
            public void AddGroupSchedule()
            {
                Group group = _isuExtraService.AddGroup("M3203");
                Teacher teacher1 = _isuExtraService.AddTeacher("Mayatin");
                DayOfWeek day = DayOfWeek.Monday;
                _isuExtraService.AddGroupSchedule(group, "OOP", teacher1, "132", 1, day);
            }
            
            [Test]
            public void AddOGNPGroupSchedule()
            {
                MegafacultyDiscipline discipline = _isuExtraService.AddDiscipline("FITIP", "M", "OSI");
                OgnpGroup group = _isuExtraService.AddOgnpGroup("Group1", discipline);
                Teacher teacher1 = _isuExtraService.AddTeacher("Mayatin");
                DayOfWeek day = DayOfWeek.Monday;
                _isuExtraService.AddOgnpGroupSchedule( discipline, group, "OOP", teacher1, "132", 1, day);
            }
            
            [Test]
            public void AddStudentOGNPGroup()
            {
                Group group = _isuExtraService.AddGroup("M3218");
                Teacher teacher1 = _isuExtraService.AddTeacher("Mayatin");
                DayOfWeek day1 = DayOfWeek.Thursday;
                _isuExtraService.AddGroupSchedule(group, "OOP", teacher1, "132", 1, day1);
                
                Student st = _isuExtraService.AddStudent(group, "Max");
                
                MegafacultyDiscipline discipline = _isuExtraService.AddDiscipline("FITIP", "M", "OSI");
                OgnpGroup ognpGroup = _isuExtraService.AddOgnpGroup("Group1", discipline);
                DayOfWeek day2 = DayOfWeek.Monday;
                _isuExtraService.AddOgnpGroupSchedule( discipline, ognpGroup, "OOP", teacher1, "132", 1, day2);
                
                _isuExtraService.AddStudentToOGNPGroup(st, ognpGroup, group);
                Assert.Contains(st, ognpGroup.GetOGNPStudent());
                
                _isuExtraService.DeleteStudentFromOGNPGroup(st, ognpGroup, discipline);
                Assert.IsEmpty(ognpGroup.GetOGNPStudent());
            }
    }
}