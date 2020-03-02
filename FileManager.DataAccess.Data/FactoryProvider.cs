namespace FileManager.DataAccess.Data
{
    public static class FactoryProvider
    {
        public static IDataFactory getFactory(string choice)
        {
            if ("VuelingFile".Equals(choice)){
                return new FileFactory();
            }
            return null;
        }
    }
}
