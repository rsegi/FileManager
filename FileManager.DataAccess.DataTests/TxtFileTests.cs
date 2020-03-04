using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Configuration;
using FileManager.Common.Layer;
using System.IO;

namespace FileManager.DataAccess.Data.Tests
{
    [TestClass()]
    public class TxtFileTests
    {
        [ClassInitialize]
        public static void TestFixtureSetup(TestContext context)
        {
            string path = ConfigurationManager.AppSettings["txtPath"];
            TxtUtils util = new TxtUtils();
            util.CreateFile();
        }

        [TestInitialize]
        public void Setup()
        {
            TxtFile txtHandler = new TxtFile();
            Student student1 = new Student(1, "Albert", "Riera", DateTime.Parse("10-10-2010"));
            Student student2 = new Student(2, "rrrrrr", "eeeee", DateTime.Parse("12-10-2012"));
            Student student3 = new Student(3, "asdf", "gbsdfg", DateTime.Parse("10-12-1999"));
            Student student4 = new Student(4, "l'Oriol", "ñññññ", DateTime.Parse("10-10-1800"));
            Student student5 = new Student(5, "jjjj", "hhhehra", DateTime.Parse("01-10-2010"));
            txtHandler.Add(student1);
            txtHandler.Add(student2);
            txtHandler.Add(student3);
            txtHandler.Add(student4);
            txtHandler.Add(student5);
        }

        [TestCleanup]
        public void TearDown()
        {
            var path = ConfigurationManager.AppSettings["txtPath"];
            JsonUtils util = new JsonUtils();
            util.CreateFile();
        }

        [ClassCleanup]
        public static void TestFixtureTearDown()
        {
            var path = ConfigurationManager.AppSettings["txtPath"];
            File.Delete(path);
        }

        [TestMethod()]
        public void AddTest()
        {
            var path = ConfigurationManager.AppSettings["txtPath"];
            TxtUtils util = new TxtUtils();
            TxtFile txt = new TxtFile();
            var studentToAdd = new Student(6, "Added", "Student", DateTime.Parse("05-07-1976"));
            txt.Add(studentToAdd);
            var studentsList = util.ListStudents(path);
            Assert.IsTrue(studentsList.Last().StudentId == studentToAdd.StudentId);
        }

        [TestMethod()]
        public void ListTest()
        {
            TxtFile txt = new TxtFile();
            var listedStudents = txt.List();
            Assert.IsNotNull(listedStudents);
        }

        [TestMethod()]
        public void RemoveTest()
        {
            var path = ConfigurationManager.AppSettings["txtPath"];
            TxtUtils util = new TxtUtils();
            TxtFile txt = new TxtFile();
            var studentToRemove = new Student(5, "jjjj", "hhhehra", DateTime.Parse("01-10-2010"));
            txt.Remove(studentToRemove);
            var studentsList = util.ListStudents(path);
            Assert.IsTrue(studentsList.Last().Name != studentToRemove.Name);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            var path = ConfigurationManager.AppSettings["txtPath"];
            TxtFile txt = new TxtFile();
            TxtUtils util = new TxtUtils();
            Student studentToUpdate = new Student(2, "Updated", "Student", DateTime.Parse("12-10-2012"));
            txt.Update(studentToUpdate);
            var studentsList = util.ListStudents(path);
            var updatedStudent = studentsList.Find(x => x.StudentId == 2);
            Assert.IsTrue(studentToUpdate.StudentId == updatedStudent.StudentId);
        }
    }
}