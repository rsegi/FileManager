namespace FileManager.DataAccess.Data
{
    public class FileFactory : IDataFactory
    {
        public VuelingFile Create(string fileType)
        {
            switch (fileType)
            {
                case "txt":
                    return new TxtFile();
                case "json":
                    return new JsonFile();
                case "xml":
                    return new XmlFile();
                default:
                    return null;
            }
        }
    }
}
