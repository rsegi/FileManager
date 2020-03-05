using FileManager.Common.Layer;
using System.Collections.Generic;

namespace FileManager.DataAccess.Data
{
    public class JsonFile : VuelingFile
    {
        readonly JsonUtils util = new JsonUtils();
        public override Student Add(Student student)
        {
            util.FileExists();
            var addedStudent = util.AddStudent(student);
            return addedStudent;
        }

        public override string List()
        {
            var message = util.ListStudents();
            return message;
        }

        public override Student Remove(Student student)
        {
            var removedStudent = util.RemoveStudent(student);
            return removedStudent;
        }

        public override Student Update(Student student)
        {
            var updatedStudent = util.UpdateStudent(student);
            return updatedStudent;
        }

        public override List<Student> GetAll()
        {
            var studentsList = util.GetListStudents();
            return studentsList;
        }
    }
}
