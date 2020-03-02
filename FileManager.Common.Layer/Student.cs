using System;

namespace FileManager.Common.Layer
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }

        public Student()
        {
        }

        public Student(int studentId, string name, string surname, DateTime birthDate)
        {
            this.StudentId = studentId;
            this.Name = name;
            this.Surname = surname;
            this.BirthDate = birthDate;
        }
    }
}
