namespace MMXEngine.Contracts.Managers
{
    public interface IDataManager
    {
        T Load<T>(string fileName);
        void Save(string fileName, object data, bool createDirectory = false);
    }
}
