using FileManager.Common.Layer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FileManager.DataAccess.Data
{
    public class XmlUtils
    {
        readonly string path = ConfigurationManager.AppSettings["xmlPath"];
        private bool FileExists()
        {
            if (File.Exists(path))
            {
                return true;
            }
            else
            {
                CreateFile();
                return false;
            }
        }

        private bool CreateFile()
        {
            XDocument doc = new XDocument(new XElement("Students"));
            doc.Save(path);
            return true;
        }

        public Student AddStudent(Student student)
        {
            XDocument doc = XDocument.Load(path);
            XElement students = doc.Element("Students");
            students.Add(new XElement("Student",
                           new XElement("StudentId", student.StudentId),
                           new XElement("Name", student.Name),
                           new XElement("Surname", student.Surname),
                           new XElement("BirthDate", student.BirthDate)));
            doc.Save(path);
            return student;
        }

        public string List()
        {
            XDocument doc = XDocument.Load(path);
            IEnumerable<XElement> listOfElements = doc.Root.Elements("Student");
            foreach (var element in listOfElements)
            {
                var studentFromFile = new Student(int.Parse(element.Element("StudentId").Value), element.Element("Name").Value, element.Element("Surname").Value, DateTime.Parse(element.Element("BirthDate").Value));
                studentsList.Add(studentFromFile);
            }
            var message = ListToString(studentsList);
            return message;
        }

        public Student RemoveStudent(Student student)
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

        public Student UpdateStudent(Student student)
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
            return null;
        }

    private string ListToString(List<Student> studentsList)
    {
        var writer = new StringBuilder();

        foreach (var studentInList in studentsList)
        {
            writer.Append(studentInList.StudentId.ToString() + "," + studentInList.Name.ToString() + "," + studentInList.Surname.ToString() + "," + studentInList.BirthDate.ToString() + "\n");
        }
        string message = writer.ToString();
        return message;
    }



}
}
