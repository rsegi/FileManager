﻿using FileManager.Common.Layer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace FileManager.DataAccess.Data
{
    public class XmlUtils
    {
        readonly string path = ConfigurationManager.AppSettings["xmlPath"];
        public bool FileExists()
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

        public bool CreateFile()
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
                           new XElement("BirthDate", student.BirthDate),
                           new XElement("GUID", student.Guid)));
            doc.Save(path);
            return student;
        }

        public string List()
        {
            var studentsList = GetStudents();
            var message = ListToString(studentsList);
            return message;
        }

        public List<Student> GetStudents()
        {
            XDocument doc = XDocument.Load(path);
            var studentsList = new List<Student>();
            IEnumerable<XElement> listOfElements = doc.Root.Elements("Student");
            foreach (var element in listOfElements)
            {
                var studentFromFile = new Student(int.Parse(element.Element("StudentId").Value), element.Element("Name").Value, element.Element("Surname").Value, DateTime.Parse(element.Element("BirthDate").Value));
                studentsList.Add(studentFromFile);
            }
            return studentsList;
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
            XElement element = doc.Root.Elements("Student").SingleOrDefault(x => x.Element("StudentId").Value.Equals(student.StudentId.ToString()));

            element.Elements("Name").FirstOrDefault().Value = student.Name;
            element.Elements("Surname").FirstOrDefault().Value = student.Surname;
            element.Elements("BirthDate").FirstOrDefault().Value = student.BirthDate.ToString();

            doc.Save(path);
            return student;
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
