using FileManager.Common.Layer;
using System.Collections.Generic;

namespace FileManager.DataAccess.Data
{
    public class XmlFile : VuelingFile
    {
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

        public override List<Student> GetAll()
        {
            var studentsList = utils.GetStudents();
            return studentsList;
        }
    }
}
