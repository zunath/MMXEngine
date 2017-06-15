using System.IO.Abstractions;
using MMXEngine.Contracts.Managers;
using Newtonsoft.Json;

namespace MMXEngine.Windows.Managers
{
    public class DataManager : IDataManager
    {
        private readonly IFileSystem _fileSystem;

        public DataManager(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public T Load<T>(string fileName)
        {   
            string path = "./Data/" + fileName;
            return JsonConvert.DeserializeObject<T>(_fileSystem.File.ReadAllText(path));
        }

        public void Save(string fileName, object data)
        {
            string path = "./Data/" + fileName;
            string json = JsonConvert.SerializeObject(data);
            _fileSystem.File.WriteAllText(path, json);
        }
    }
}
