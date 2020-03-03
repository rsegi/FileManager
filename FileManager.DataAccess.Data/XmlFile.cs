using FileManager.Common.Layer;
using System.Configuration;

namespace FileManager.DataAccess.Data
{
    public class XmlFile : VuelingFile
    {
        readonly string path = ConfigurationManager.AppSettings["xmlPath"];
        readonly XmlUtils utils = new XmlUtils();
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
            var updatedStudent = utils.UpdateStudent(student);
            return updatedStudent;
        }
    }
}
