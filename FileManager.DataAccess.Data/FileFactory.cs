using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace FileManager.DataAccess.Data
{
    public class FileFactory : IDataFactory
    {
        private readonly string path = ConfigurationManager.AppSettings["repositoryConfigurationPath"];
        public VuelingFile Create(string type)
        {
            var myAssembly = Assembly.GetExecutingAssembly();
            XElement root = XElement.Load(path);
            IEnumerable<XElement> repository = from element in root.Elements("Type")
                                               where (string)element.Attribute("Id") == type
                                               select element;
            var fileType = repository.First().Element("class").Value;
            Type newFileManager = myAssembly.GetType(fileType);
            return Activator.CreateInstance(newFileManager) as VuelingFile;

        }
    }
}
