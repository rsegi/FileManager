using FileManager.Common.Layer;
using System;

namespace FileManager.DataAccess.Data
{
    public interface IStudentDao
    {
        Boolean AddStudent(Student student);
        Student UpdateStudent(Student student);
        Student RemoveStudent(Student student);
        string ListStudents();

    }
}
