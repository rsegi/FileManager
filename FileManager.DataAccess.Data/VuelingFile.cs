using FileManager.Common.Layer;
using System.Collections.Generic;

namespace FileManager.DataAccess.Data
{
    public abstract class VuelingFile
    {
        public readonly string path;
        
        public abstract Student Add(Student student);
        public abstract Student Update(Student student);
        public abstract Student Remove(Student student);
        public abstract string List();
        public abstract List<Student> GetAll();
    }
}
