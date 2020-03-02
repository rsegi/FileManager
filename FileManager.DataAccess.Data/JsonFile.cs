using FileManager.Common.Layer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;

namespace FileManager.DataAccess.Data
{
    public class JsonFile : VuelingFile
    {
        readonly string path = ConfigurationManager.AppSettings["jsonPath"];

        public override Student Add(Student student)
        {
            var jsonString = "";
            var studentsList = new List<Student>();
            if (!File.Exists(path))
            {
                studentsList.Add(student);
                jsonString = JsonConvert.SerializeObject(studentsList.ToArray());

                File.WriteAllText(path, jsonString);
            }
            else
            {
                using (var reader = new StreamReader(path))
                {
                    jsonString = reader.ReadToEnd();
                }
                studentsList = JsonConvert.DeserializeObject<List<Student>>(jsonString);

                studentsList.Add(student);
                jsonString = JsonConvert.SerializeObject(studentsList);
                File.WriteAllText(path, jsonString);
            }          
            return student;
        }

        public override string List()
        {
            if (File.Exists(path))
            {
                var jsonString = "";
                var writer = new StringBuilder();
                using (var reader = new StreamReader(path))
                {
                    jsonString = reader.ReadToEnd();
                }
                var studentsList = JsonConvert.DeserializeObject<List<Student>>(jsonString);

                foreach (var student in studentsList)
                {
                    writer.Append(student.StudentId.ToString() + "," + student.Name.ToString() + "," + student.Surname.ToString() + "," + student.BirthDate.ToString() + "\n");
                }
                var message = writer.ToString();
                return message;
            }
            return null;
        }

        public override Student Remove(Student student)
        {
            if (File.Exists(path))
            {
                var jsonString = "";
                using (StreamReader reader = new StreamReader(path))
                {
                    jsonString = reader.ReadToEnd();
                }
                List<Student> studentsList = JsonConvert.DeserializeObject<List<Student>>(jsonString);
                Student studentToRemove = studentsList.Find(x => x.StudentId == student.StudentId);
                studentsList.Remove(studentToRemove);

                var json = JsonConvert.SerializeObject(studentsList);
                File.WriteAllText(path, json);

                return student;
            }
            return null;
        }

        public override Student Update(Student student)
        {
            if (File.Exists(path))
            {
                var jsonString = "";
                using (StreamReader reader = new StreamReader(path))
                {
                    jsonString = reader.ReadToEnd();
                }
                List<Student> studentsList = JsonConvert.DeserializeObject<List<Student>>(jsonString);
                Student studentToRemove = studentsList.Find(x => x.StudentId == student.StudentId);
                studentsList.Remove(studentToRemove);

                studentsList.Add(student);

                var json = JsonConvert.SerializeObject(studentsList);
                File.WriteAllText(path, json);
            }
            return student;
            }
    }
}
