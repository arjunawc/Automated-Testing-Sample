using System.IO;
using Newtonsoft.Json;
using RestSharp.Serializers;

namespace AutomationTests.Resources
{
    public class JsonSerializer : ISerializer
    {
        private readonly Newtonsoft.Json.JsonSerializer _jsonSerializer;
        public string ContentType { get; set; }
        public string DateFormat { get; set; }
        public string Namespace { get; set; }
        public string RootElement { get; set; }

        public JsonSerializer()
        {
            _jsonSerializer = new Newtonsoft.Json.JsonSerializer();
            ContentType = "application/json";
        }

        public string Serialize(object obj)
        {
            using (StringWriter sWriter = new StringWriter())
            {
                using (JsonTextWriter jsonWriter = new JsonTextWriter(sWriter))
                {
                    jsonWriter.Formatting = Formatting.Indented;
                    _jsonSerializer.Serialize(jsonWriter, obj);
                }
                return sWriter.ToString();
            }
        }
    }
}
