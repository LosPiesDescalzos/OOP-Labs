using Isu.Services;
using Isu.Tools;
using NUnit.Framework;

namespace Isu.Tests
{
    public class Tests
    {
        private IIsuService _isuService;

        [SetUp]
        public void Setup()
        {
            _isuService = new IsuServices(5);
        }

        [Test]
        public void AddStudentToGroup_StudentHasGroupAndGroupContainsStudent()
        {
            Group gr = _isuService.AddGroup("M3203");
            Student st = _isuService.AddStudent(gr, "Max");
            Assert.Contains(st, gr.Students);
        }

        [Test]
        public void ReachMaxStudentPerGroup_ThrowException()
        {
            Assert.Catch<IsuException>(() =>
            {
                Group gr = _isuService.AddGroup("M3201");
                Student st = _isuService.AddStudent(gr,"Artem");
                Student st1 = _isuService.AddStudent(gr,"Dmitriy");
                Student st2 = _isuService.AddStudent(gr,"Nikita");
                Student st3 = _isuService.AddStudent(gr,"Max");
                Student st4 = _isuService.AddStudent(gr,"Katerina");
                Student st5 = _isuService.AddStudent(gr,"Viktoria");
                });
        }

        [Test]
        public void CreateGroupWithInvalidName_ThrowException()
        {
            Assert.Catch<IsuException>(() =>
            {
                Group gr = _isuService.AddGroup("N302");
               });
            Assert.Catch<IsuException>(() =>
            {
                Group gr = _isuService.AddGroup("N3502");
            });
            Assert.Catch<IsuException>(() =>
            {
                Group gr = _isuService.AddGroup("N32A2");
            });
            Assert.Catch<IsuException>(() =>
            {
                Group gr = _isuService.AddGroup("N3802");
            });
        }

        [Test]
        public void TransferStudentToAnotherGroup_GroupChanged()
        {
            Group gr = _isuService.AddGroup("M3209"); 
            Group newgr = _isuService.AddGroup("M3205");
            Student st = _isuService.AddStudent(gr, "Maria");
            _isuService.ChangeStudentGroup(st, newgr);
          }
    }
}