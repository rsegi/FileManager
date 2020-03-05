using FileManager.Common.Layer;
using System.Collections.Generic;

namespace FileManager.DataAccess.Data
{
    public class TxtFile : VuelingFile
    {
        readonly TxtUtils utils = new TxtUtils();

        public override Student Add(Student student)
        {
            utils.FileExists();
            var studentAdded = utils.AddStudent(student);
            return studentAdded;
        }

        public override string List()
        {
            utils.FileExists();
            var list = utils.List();
            return list;           
        }

        public override Student Remove(Student student)
        {
            utils.FileExists();
            var removedStudent = utils.RemoveStudent(student);
            return removedStudent;
        }

        public override Student Update(Student student)
        {
            utils.FileExists();
            var updatedStudent = utils.UpdateStudent(student);
            return updatedStudent;
        }

        public override List<Student> GetAll()
        {
            var studentsList = utils.ListStudents();
            return studentsList;
        }
    }
}
