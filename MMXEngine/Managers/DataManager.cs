using System.IO;
using MMXEngine.Interfaces.Managers;
using Newtonsoft.Json;

namespace MMXEngine.Windows.Managers
{
    public class DataManager : IDataManager
    {
        public T Load<T>(string fileName)
        {
            fileName = Path.GetFileNameWithoutExtension(fileName);
            string path = "./Data/" + fileName + ".json";

            return JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
        }

        public void Save(string fileName, object data)
        {
            fileName = Path.GetFileNameWithoutExtension(fileName);
            string path = "./Data/" + fileName + ".json";
            string json = JsonConvert.SerializeObject(data);
            File.WriteAllText(path, json);
        }
    }
}
