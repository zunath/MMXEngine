namespace MMXEngine.Interfaces.Managers
{
    public interface IDataManager
    {
        T Load<T>(string fileName);
        void Save(string fileName, object data);
    }
}
