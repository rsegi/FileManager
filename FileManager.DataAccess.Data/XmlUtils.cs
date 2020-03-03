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
    class XmlUtils
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



    }
}
