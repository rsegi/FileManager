using FileManager.Common.Layer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace FileManager.DataAccess.Data
{
    public class XmlStudentDao : IStudentDao
    {
        readonly string path = ConfigurationManager.AppSettings["xmlPath"];
        public Boolean AddStudent(Student student)
        {          
            if (!File.Exists(path))
            {
                XDocument doc = new XDocument(new XElement("Students",
                    new XElement("Student",
                       new XElement("StudentId", student.StudentId),
                       new XElement("Name", student.Name),
                       new XElement("Surname", student.Surname),
                       new XElement("BirthDate", student.BirthDate))));
                doc.Save(path);
            }
            else
            {
                XDocument doc = XDocument.Load(path);
                XElement students = doc.Element("Students");
                students.Add(new XElement("Student",
                           new XElement("StudentId", student.StudentId),
                           new XElement("Name", student.Name),
                           new XElement("Surname", student.Surname),
                           new XElement("BirthDate", student.BirthDate)));
                doc.Save(path);
            }
            return true;
        }

        public string ListStudents()
        {
            var studentsList = new List<Student>();
            if (File.Exists(path))
            {
                XDocument doc = XDocument.Load(path);
                IEnumerable<XElement> listOfElements = doc.Root.Elements("Student");
                foreach(var element in listOfElements)
                {
                    var studentFromFile = new Student();
                    studentFromFile.StudentId = int.Parse(element.Element("StudentId").Value);
                    studentFromFile.Name = element.Element("Name").Value;
                    studentFromFile.Surname = element.Element("Surname").Value;
                    studentFromFile.BirthDate = DateTime.Parse(element.Element("BirthDate").Value);

                    studentsList.Add(studentFromFile);
                }
                var writer = new StringBuilder();

                foreach(var studentInList in studentsList)
                {
                    writer.Append(studentInList.StudentId.ToString() + "," + studentInList.Name.ToString() + "," + studentInList.Surname.ToString() + "," + studentInList.BirthDate.ToString() + "\n");
                }
                string message = writer.ToString();

                return message;
            }
            return null;
        }

        public Student RemoveStudent(Student student)
        {
            if (File.Exists(path))
            {
                var childToErase = "descendant::Student[StudentId='" + student.StudentId.ToString() + "']";
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNode root = doc.DocumentElement;
                XmlNode node = root.SelectSingleNode(childToErase);
                node.ParentNode.RemoveChild(node);

                doc.Save(path);

                return student;
            }
            return null;
        }

        public Student UpdateStudent(Student student)
        {
            if (File.Exists(path))
            {
                XDocument doc = XDocument.Load(path);
                IEnumerable<XElement> listOfElements = doc.Root.Elements("Student").Where(x => x.Element("StudentID").Value == student.StudentId.ToString());
                if (listOfElements.Any())
                {
                    listOfElements.Elements("Name").FirstOrDefault().Value = student.Name;
                    listOfElements.Elements("Surname").FirstOrDefault().Value = student.Surname;
                    listOfElements.Elements("BirthDate").FirstOrDefault().Value = student.BirthDate.ToString();

                    doc.Save(path);
                    return student;
                }
            }
            return null;
        }
    }
}
