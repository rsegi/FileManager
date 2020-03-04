using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;
using System.Linq;
using FileManager.Common.Layer;
using System.IO;

namespace FileManager.DataAccess.Data.Tests
{
    [TestClass()]
    public class JsonFileTests
    {
        [ClassInitialize]
        public static void TestFixtureSetup(TestContext context)
        {
            string path = ConfigurationManager.AppSettings["jsonPath"];
            JsonUtils util = new JsonUtils();
            util.CreateFile();
        }

        [TestInitialize]
        public void Setup()
        {
            JsonFile jsonHandler = new JsonFile();
            Student student1 = new Student(1, "Albert", "Riera", DateTime.Parse("10-10-2010"));
            Student student2 = new Student(2, "rrrrrr", "eeeee", DateTime.Parse("12-10-2012"));
            Student student3 = new Student(3, "asdf", "gbsdfg", DateTime.Parse("10-12-1999"));
            Student student4 = new Student(4, "l'Oriol", "ñññññ", DateTime.Parse("10-10-1800"));
            Student student5 = new Student(5, "jjjj", "hhhehra", DateTime.Parse("01-10-2010"));
            jsonHandler.Add(student1);
            jsonHandler.Add(student2);
            jsonHandler.Add(student3);
            jsonHandler.Add(student4);
            jsonHandler.Add(student5);
        }

        [TestCleanup]
        public void TearDown()
        {
            string path = ConfigurationManager.AppSettings["jsonPath"];
            JsonUtils util = new JsonUtils();
            util.CreateFile();
        }
        [ClassCleanup]
        public static void TestFixtureTearDown()
        {
            var path = ConfigurationManager.AppSettings["jsonPath"];
            File.Delete(path);
        }
        // Mark that this is a unit test method. (Required)
        [TestMethod()]
        public void AddTest()
        {
            JsonUtils util = new JsonUtils();
            JsonFile json = new JsonFile();
            Student testStudent = new Student(6, "AddStudent", "Test", DateTime.Parse("15-05-1995"));
            json.Add(testStudent);
            var studentsList = util.GetListStudents();
            Assert.IsTrue(testStudent == studentsList.Last());
        }

        [TestMethod()]
        public void RemoveTest()
        {
            JsonUtils util = new JsonUtils();
            JsonFile json = new JsonFile();
            Student testStudent = new Student(5, "jjjj", "hhhehra", DateTime.Parse("01-10-2010"));
            var studentsList = util.GetListStudents();
            json.Remove(testStudent);
            Assert.IsTrue(testStudent != studentsList.Last());
        }

        [TestMethod()]
        public void UpdateTest()
        {
            JsonUtils util = new JsonUtils();
            JsonFile json = new JsonFile();
            Student studentToUpdate = new Student(2, "Updated", "Student", DateTime.Parse("12-10-2012"));
            json.Update(studentToUpdate);
            var studentsList = util.GetListStudents();
            var updatedStudent = studentsList.Find(x => x.StudentId == 2);
            Assert.IsTrue(studentToUpdate == updatedStudent);
        }

        [TestMethod()]
        public void ListTest()
        {
            JsonFile json = new JsonFile();
            var listedStudents = json.List();
            Assert.IsNotNull(listedStudents);
        }
    }
}