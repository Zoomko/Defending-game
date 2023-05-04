using Newtonsoft.Json;
using System.IO;

namespace Assets.CodeBase.Services
{
    public class JsonDataService : ILoadSaveDataFormat
    {
        public T Load<T>(string path)
        {
            T data = default;
            if (File.Exists(path))
            {

                using (StreamReader file = File.OpenText(path))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    data = (T)serializer.Deserialize(file, typeof(T));

                }
            }
            else
                File.CreateText(path);
            return data;
        }

        public void Save<T>(string path, T data)
        {
            using (StreamWriter file = File.CreateText(path))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, data);
            }
        }
    }
}
