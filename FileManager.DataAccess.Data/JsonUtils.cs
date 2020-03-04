using FileManager.Common.Layer;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using System;

namespace FileManager.DataAccess.Data
{
    public class JsonUtils
    {
        readonly string path = ConfigurationManager.AppSettings["jsonPath"];
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

        public bool CreateFile()
        {
            using (File.Create(path))
            {
                return true;
            }
        }

        public Student AddStudent(Student student)
        {
            var studentsList = GetListStudents();
            if (studentsList == null)
            {
                studentsList = new List<Student>();
            }
            studentsList.Add(student);
            var jsonString = JsonConvert.SerializeObject(studentsList.ToArray());
            File.WriteAllText(path, jsonString);

            return student;
        }

        public string ListStudents()
        {
            var studentsList = GetListStudents();
            var writer = new StringBuilder();
            foreach (var student in studentsList)
            {
                writer.Append(student.StudentId.ToString() + "," + student.Name.ToString() + "," + student.Surname.ToString() + "," + student.BirthDate.ToString() + "\n");
            }
            var message = writer.ToString();
            return message;
        }

        public Student RemoveStudent(Student student)
        {
            var studentsList = GetListStudents();
            Student studentToRemove = studentsList.Find(x => x.StudentId == student.StudentId);
            studentsList.Remove(studentToRemove);

            var json = JsonConvert.SerializeObject(studentsList);
            File.WriteAllText(path, json);
            return student;
        }

        public Student UpdateStudent(Student student)
        {
            var studentsList = GetListStudents();
            Student studentToRemove = studentsList.Find(x => x.StudentId == student.StudentId);
            studentsList.Remove(studentToRemove);

            studentsList.Add(student);

            var json = JsonConvert.SerializeObject(studentsList);
            File.WriteAllText(path, json);

            return student;
        }

        public List<Student> GetListStudents()
        {
            var jsonString = "";
            using (var reader = new StreamReader(path))
            {
                jsonString = reader.ReadToEnd();
            }
            var studentsList = JsonConvert.DeserializeObject<List<Student>>(jsonString);
            return studentsList;
        }


    }
}
