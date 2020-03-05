using FileManager.Common.Layer;
using FileManager.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace FileManager.Business.Layer
{
    public class FileManagerBll
    {
        readonly CultureInfo provider = new CultureInfo("es-ES");
        public Student Add(string id, string name, string surname, string birthDate, string type)
        {
            Student studentToAdd = new Student();
            studentToAdd.StudentId = int.Parse(id);
            studentToAdd.Name = name;
            studentToAdd.Surname = surname;
            studentToAdd.BirthDate = DateTime.ParseExact(birthDate, "dd/MM/yyyy", provider);
            studentToAdd.Guid = Guid.NewGuid();

            string choice = "VuelingFile";

            var factory = FactoryProvider.getFactory(choice);
            var fileFactory = factory.Create(type);
            fileFactory.Add(studentToAdd);

            return studentToAdd;
        }

        public Student Remove(string id, string name, string surname, string birthDate, string type)
        {
            Student studentToRemove = new Student();
            studentToRemove.StudentId = int.Parse(id);
            studentToRemove.Name = name;
            studentToRemove.Surname = surname;
            studentToRemove.BirthDate = DateTime.ParseExact(birthDate, "dd/MM/yyyy", provider);
            studentToRemove.Guid = Guid.NewGuid();

            string choice = "VuelingFile";

            var factory = FactoryProvider.getFactory(choice);
            var fileFactory = factory.Create(type);
            fileFactory.Remove(studentToRemove);

            return studentToRemove;
        }

        public Student Update(string id, string name, string surname, string birthDate, string type)
        {
            Student studentToUpdate = new Student();
            studentToUpdate.StudentId = int.Parse(id);
            studentToUpdate.Name = name;
            studentToUpdate.Surname = surname;
            studentToUpdate.BirthDate = DateTime.ParseExact(birthDate, "dd/MM/yyyy", provider);
            studentToUpdate.Guid = Guid.NewGuid();

            string choice = "VuelingFile";

            var factory = FactoryProvider.getFactory(choice);
            var fileFactory = factory.Create(type);
            fileFactory.Remove(studentToUpdate);

            return studentToUpdate;
        }

        public string GetAll(string type)
        {
            string choice = "VuelingFile";

            var factory = FactoryProvider.getFactory(choice);
            var fileFactory = factory.Create(type);
            var studentsList = fileFactory.GetAll();
            var writer = new StringBuilder();
            foreach (var student in studentsList)
            {
                var birthDate = student.BirthDate;
                var now = DateTime.Now;
                var age = (now - birthDate).TotalDays;
                var ageInYears = Math.Floor((age / 365));
                writer.Append(student.StudentId.ToString() +  ", " + student.Name.ToString() + ", " + student.Surname.ToString() + ", " + student.BirthDate.ToString() + ", " + ageInYears + ". ");

            }
            var message = writer.ToString();
            return message;
        }
    }
}
