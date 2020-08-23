using RestSharp;

namespace AutomationTests.Resources
{
    public class JsonRestRequest : RestRequest
    {
        public JsonRestRequest(Method method, string resource)
        {
            RequestFormat = DataFormat.Json;
            AddHeader("Content-Type", "application/json");
            JsonSerializer = new JsonSerializer();
            this.Method = method;
            this.Resource = resource;
        }
    }
}
