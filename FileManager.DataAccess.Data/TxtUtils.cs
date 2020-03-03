using FileManager.Common.Layer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;

namespace FileManager.DataAccess.Data
{
    class TxtUtils
    {
        readonly string path = ConfigurationManager.AppSettings["txtPath"];

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

        private bool CreateFile()
        {
            using (File.Create(path))
            {
                return true;
            }
        }

        public Student AddStudent(Student student)
        {
            var writer = new StringBuilder();

            writer.AppendLine($"{student.StudentId},{student.Name},{student.Surname},{student.BirthDate}");

            File.AppendAllText(path, writer.ToString());

            return student;
        }

        public Student UpdateStudent(Student student)
        {
            var util = new TxtUtils();
            var writer = new StringBuilder();
            var studentsList = util.ListStudents(path);

            Student studentToErase = studentsList.Find(x => x.StudentId == student.StudentId);
            studentsList.Remove(studentToErase);
            studentsList.Add(student);

            foreach (var element in studentsList)
            {
                writer.AppendLine($"{element.StudentId},{element.Name},{element.Surname},{element.BirthDate}");
                File.WriteAllText(path, writer.ToString());
            }
            return student;
        }

        public Student RemoveStudent(Student student)
        {
            var util = new TxtUtils();
            var writer = new StringBuilder();
            var studentsList = util.ListStudents(path);

            Student studentToErase = studentsList.Find(x => x.StudentId == student.StudentId);
            studentsList.Remove(studentToErase);

            foreach (var element in studentsList)
            {
                writer.AppendLine($"{element.StudentId},{element.Name},{element.Surname},{element.BirthDate}");
                File.WriteAllText(path, writer.ToString());
            }
            return student;
        }

        public string List()
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

        private List<Student> ListStudents(string path)
        {
            var util = new TxtUtils();

            using (var reader = new StreamReader(path))
            {
                var studentsList = util.ListStudentsFromFile(reader);
                return studentsList;
            }
        }

        private List<Student> ListStudentsFromFile(StreamReader reader)
        {
            var studentsList = new List<Student>();
            var util = new TxtUtils();
            while (!reader.EndOfStream)
            {
                var studentToAdd = util.SetValuesString(reader);
                studentsList.Add(studentToAdd);
            }
            return studentsList;
        }

        private Student SetValuesString(StreamReader reader)
        {
            var line = reader.ReadLine();
            var values = line.Split(',');
            var studentInTxt = new Student
            (
                int.Parse(values[0]),
                values[1],
                values[2],
                DateTime.Parse(values[3])
            );
            return studentInTxt;
        }
    }
}
