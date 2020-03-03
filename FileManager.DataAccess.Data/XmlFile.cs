using FileManager.Common.Layer;
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
    public class XmlFile : VuelingFile
    {
        readonly string path = ConfigurationManager.AppSettings["xmlPath"];
        var utils = XmlUtils();
        public override Student Add(Student student)
        {
            utils.FileExists();
            var addedStudent = utils.AddStudent(student);
            return addedStudent;
        }

        public override string List()
        {
            var message = utils.List();
            return message;
        }

        public override Student Remove(Student student)
        {
            var removedStudent = utils.RemoveStudent(student);
            return removedStudent;
        }

        public override Student Update(Student student)
        {
            var updatedStudent = utils.UpdateStudent();
            return updatedStudent;
        }
    }
}
