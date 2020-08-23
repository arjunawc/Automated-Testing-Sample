using AutomationTests.Framework.Data.ResponseObject;
using AutomationTests.Resources;
using RestSharp;
using System.Collections.Generic;

namespace AutomationTests.Framework.EndPoints.ForecastAPI
{
    public class WeatherForecastEndPoint : BaseEndpoint
    {
        public IRestResponse<List<Forecast>> GetForecasts()
        {
            string resource = APIResources.GetWeatherForecastResource;
            var request = new JsonRestRequest(Method.GET, resource);

            var response = ExecuteJsonRequest<List<Forecast>>(request);
            StatusCode = response.StatusCode;

            return response;
        }
    }
}
