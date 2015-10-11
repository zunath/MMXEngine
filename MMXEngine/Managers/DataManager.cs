using System.IO;
using MMXEngine.Interfaces.Managers;
using Newtonsoft.Json;

namespace MMXEngine.Windows.Managers
{
    public class DataManager : IDataManager
    {
        public T Load<T>(string fileName)
        {   
            string path = "./Data/" + fileName;
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
        }

        public void Save(string fileName, object data)
        {
            string path = "./Data/" + fileName;
            string json = JsonConvert.SerializeObject(data);
            File.WriteAllText(path, json);
        }
    }
}
