

using Newtonsoft.Json;

namespace Lecture18.Dynamic
{
    public class JsonReader
    {
        public dynamic? ReadJson(string filePath)
        {
            var text = File.ReadAllText(filePath);
            dynamic? toReturn = JsonConvert.DeserializeObject<dynamic>(text);
            
            return toReturn;
        }

        public void WriteJson(string filePath, dynamic value)
        {
            var serialized = JsonConvert.SerializeObject(value);
            File.WriteAllText(filePath, serialized);
        }
    }
}
