using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Isu.Tools;

namespace Isu.Services
{
    public class IsuServices : IIsuService
    {
        private int _maxStudent;
        private List<Group> _studentGroup = new List<Group>();

        public IsuServices(int maxStudent)
        {
            _maxStudent = maxStudent;
        }

        public Group AddGroup(string name)
        {
           /* int lenghtGroup = 5;
            int maxCourse = 4;
            int minCourse = 1;
            string firstLetters = name.Substring(0, 2);
            int count = name.Length;
            if (count != lenghtGroup)
                throw new IsuException("Invalid name");

            string subCourse = name.Substring(2, 1);
            string subLatters = name.Substring(3, 2);
            bool chekCourse = int.TryParse(subCourse, out int course);
            bool chekLastLetters = int.TryParse(subLatters, out int lastLetters);
            if (!chekCourse || !chekLastLetters)
            {
                throw new IsuException("Invalid name");
            }
            else if (firstLetters != "M3" || course > maxCourse || course < minCourse)
            {
                throw new IsuException("Invalid name");
            }*/
            var group = new Group(name);
            _studentGroup.Add(group);
            return group;
        }

        public Student AddStudent(Group group, string name)
        {
            Student studName = new Student(name);
            foreach (var gr in _studentGroup)
            {
                if (gr.Students.Count < _maxStudent)
                {
                    if (gr.Name == group.Name)
                    {
                        gr.Students.Add(studName);
                    }
                }
                else
                {
                   throw new IsuException("group is full");
                }
            }

            return studName;
        }

        public Student GetStudent(int id)
        {
            foreach (var gr in _studentGroup)
            {
                foreach (var st in gr.Students)
                {
                    if (st.Id == id)
                    {
                        return st;
                    }
                }
            }

            throw new IsuException("not found");
        }

        public Student FindStudent(string name)
        {
            foreach (var gr in _studentGroup)
            {
                foreach (var st in gr.Students)
                {
                    if (st.Name == name)
                    {
                     return st;
                    }
                }
            }

            return null;
        }

        public List<Student> FindStudents(string groupName)
        {
            foreach (var gr in _studentGroup)
            {
                if (gr.Name == groupName)
                {
                    return gr.Students;
                }
            }

            throw new IsuException("not found");
        }

        public List<Student> FindStudents(CourseNumber courseNumber)
        {
            List<Student> groupStud = new List<Student>();
            foreach (var gr in _studentGroup)
            {
                foreach (var st in gr.Students)
                {
                    if (gr.Course == courseNumber)
                    {
                        groupStud.Add(st);
                    }
                }
            }

            return groupStud;
        }

        public Group FindGroup(string groupName)
        {
            foreach (Group gr in _studentGroup)
            {
                if (gr.Name == groupName)
                {
                    return gr;
                }
            }

            return null;
        }

        public List<Group> FindGroups(CourseNumber courseNumber)
        {
            List<Group> groups = new List<Group>();
            foreach (var gr in _studentGroup)
            {
                if (gr.Course == courseNumber)
                {
                    groups.Add(gr);
                }
            }

            return groups;
        }

        public void ChangeStudentGroup(Student student, Group newGroup)
        {
            foreach (var gr in _studentGroup)
            {
                foreach (var st in gr.Students.ToList())
                {
                    if (st.Id == student.Id)
                    {
                        gr.Students.Remove(st);
                        AddStudent(newGroup, st.Name);
                    }
                }
            }
        }
    }
}