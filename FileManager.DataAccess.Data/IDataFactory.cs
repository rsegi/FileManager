namespace FileManager.DataAccess.Data
{
    public interface IDataFactory
    {
        VuelingFile Create(string fileType);
    }
}
