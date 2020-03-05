using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Configuration;
using FileManager.Common.Layer;
using System.IO;

namespace FileManager.DataAccess.Data.Tests
{
    [TestClass()]
    public class XmlFileTests
    {
        [ClassInitialize]
        public static void TestFixtureSetup(TestContext context)
        {
            string path = ConfigurationManager.AppSettings["xmlPath"];
            XmlUtils util = new XmlUtils();
            util.CreateFile();
        }

        [TestInitialize]
        public void Setup()
        {
            XmlFile txtHandler = new XmlFile();
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
            var path = ConfigurationManager.AppSettings["xmlPath"];
            XmlUtils util = new XmlUtils();
            util.CreateFile();
        }

        [ClassCleanup]
        public static void TestFixtureTearDown()
        {
            var path = ConfigurationManager.AppSettings["xmlPath"];
            File.Delete(path);
        }

        [TestMethod()]
        public void AddTest()
        {
            XmlUtils util = new XmlUtils();
            XmlFile xml = new XmlFile();
            var studentToAdd = new Student(6, "Added", "Student", DateTime.Parse("05-07-1976"));
            xml.Add(studentToAdd);
            var studentsList = util.GetStudents();
            Assert.IsTrue(studentsList.Last().StudentId == studentToAdd.StudentId);
        }

        [TestMethod()]
        public void ListTest()
        {
            XmlFile xml = new XmlFile();
            var listedStudents = xml.List();
            Assert.IsNotNull(listedStudents);
        }

        [TestMethod()]
        public void RemoveTest()
        {
            XmlUtils util = new XmlUtils();
            XmlFile xml = new XmlFile();
            var studentToRemove = new Student(5, "jjjj", "hhhehra", DateTime.Parse("01-10-2010"));
            xml.Remove(studentToRemove);
            var studentsList = util.GetStudents();
            Assert.IsTrue(studentsList.Last().StudentId != studentToRemove.StudentId);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            XmlFile xml = new XmlFile();
            XmlUtils util = new XmlUtils();
            Student studentToUpdate = new Student(2, "Updated", "Student", DateTime.Parse("12-10-2012"));
            xml.Update(studentToUpdate);
            var studentsList = util.GetStudents();
            var updatedStudent = studentsList.Find(x => x.StudentId == 2);
            Assert.IsTrue(studentToUpdate.StudentId == updatedStudent.StudentId);
        }
    }
}