using AutomationTests.Framework.AutomationConfiguration;
using AutomationTests.Resources;
using RestSharp;
using System.Net;

namespace AutomationTests.Framework.EndPoints
{
    public class BaseEndpoint
    {
        public virtual string BaseUrl
        {
            get { return ApiEnvironment.BaseUrl; }
        }

        public HttpStatusCode StatusCode { get; set; }


        public IRestResponse<T> ExecuteJsonRequest<T>(JsonRestRequest request) where T : new()
        {
            RestClient client = new RestClient(BaseUrl);
            client.AddHandler("application/json", () => { return new JsonDeserializer(); });
            IRestResponse<T> response = client.Execute<T>(request);

            return response;
        }
    }
}
