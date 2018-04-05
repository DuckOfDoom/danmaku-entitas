using Newtonsoft.Json;

namespace DuckOfDoom.Danmaku.Configuration
{
    public class JsonSerializer : IJsonSerializer
    {
        public string ToJson<T>(T obj, bool pretty = false)
        {
            return JsonConvert.SerializeObject(obj, pretty ? Formatting.Indented : Formatting.None);
        }

        public T FromJson<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }

    public interface IJsonSerializer
    {
        string ToJson<T>(T obj, bool pretty = false);
        T FromJson<T>(string json);
    }
}