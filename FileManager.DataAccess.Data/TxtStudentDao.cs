using System;
using System.IO;
using System.Text;
using System.Configuration;
using FileManager.Common.Layer;
using System.Collections.Generic;

namespace FileManager.DataAccess.Data
{
    
    public class TxtStudentDao : IStudentDao
    {
        readonly string path = ConfigurationManager.AppSettings["txtPath"];
        public Boolean AddStudent(Student student)
        {
            var writer = new StringBuilder();

            writer.AppendLine($"{student.StudentId},{student.Name},{student.Surname},{student.BirthDate}");

            File.AppendAllText(path, writer.ToString());

            return true;
        }

        public string ListStudents()
        {
            if (File.Exists(path))
            {
                var writer = new StringBuilder();
                using (var reader = new StreamReader(path))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();

                        writer.Append(line + "\n");
                    }
                }
                string message = writer.ToString();
                return message;
            }
            return null;
            
        }

        public Student RemoveStudent(Student student)
        {
            if (File.Exists(path))
            {
                var writer = new StringBuilder();
                var studentsList = new List<Student>();
                using (var reader = new StreamReader(path))
                {
                    while (!reader.EndOfStream)
                    {
                        var studentInTxt = new Student();
                        var line = reader.ReadLine();
                        var values = line.Split(',');

                        studentInTxt.StudentId = int.Parse(values[0]);
                        studentInTxt.Name = values[1];
                        studentInTxt.Surname = values[2];
                        studentInTxt.BirthDate = DateTime.Parse(values[3]);

                        studentsList.Add(studentInTxt);
                    }
                }
                Student studentToErase = studentsList.Find(x => x.StudentId == student.StudentId);
                studentsList.Remove(studentToErase);

                foreach (var element in studentsList)
                {
                    writer.AppendLine($"{element.StudentId},{element.Name},{element.Surname},{element.BirthDate}");

                    File.WriteAllText(path, writer.ToString());
                }
                return student;
            }
            return null;
        }

        public Student UpdateStudent(Student student)
        {
            if (File.Exists(path))
            {
                var writer = new StringBuilder();
                var studentsList = new List<Student>();
                using (var reader = new StreamReader(path))
                {
                    while (!reader.EndOfStream)
                    {
                        var studentInTxt = new Student();
                        var line = reader.ReadLine();
                        var values = line.Split(',');

                        studentInTxt.StudentId = int.Parse(values[0]);
                        studentInTxt.Name = values[1];
                        studentInTxt.Surname = values[2];
                        studentInTxt.BirthDate = DateTime.Parse(values[3]);

                        studentsList.Add(studentInTxt);
                    }
                }
                Student studentToUpdate = studentsList.Find(x => x.StudentId == student.StudentId);
                studentsList.Remove(studentToUpdate);

                studentsList.Add(student);

                foreach (var element in studentsList)
                {
                    writer.AppendLine($"{element.StudentId},{element.Name},{element.Surname},{element.BirthDate}");

                    File.WriteAllText(path, writer.ToString());
                }
                return student;
            }
            return null;
        }
    }
}
