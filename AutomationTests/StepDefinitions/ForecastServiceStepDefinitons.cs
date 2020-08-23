using AutomationTests.Framework.EndPoints.ForecastAPI;
using Automatted_Testing_Sample;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace AutomationTests.StepDefinitions
{
    [Binding]
    public class ForecastServiceStepDefinitons
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly WeatherForecastEndPoint _weatherForecastEndPoint;

        public ForecastServiceStepDefinitons(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _weatherForecastEndPoint = new WeatherForecastEndPoint();
        }

        [Given(@"I run the forecast api")]
        public void GivenIRunTheForecastApi()
        {
            var response = _weatherForecastEndPoint.GetForecasts();

            _scenarioContext["ForecastResponseData"] = response.Data;
            _scenarioContext["ForecastResponseCode"] = (int)response.StatusCode;
        }

        [Then(@"response should be returning code (.*)")]
        public void ThenSuccessfulResponseShouldBeReturned(int code)
        {
            Assert.AreEqual(code, _scenarioContext["ForecastResponseCode"], $"Response code is not {code}");
        }


        [Then(@"forecasts returned is equal to (.*)")]
        public void ForecastsReturnedIsEqualTo(int forecasts)
        {
            var response = JArray.Parse(JsonConvert.SerializeObject(_scenarioContext["ForecastResponseData"]));
            Assert.AreEqual(forecasts, response.Count(), $"Forecast count is not equal to {forecasts}");
        }

        [Then(@"the date should be a future date")]
        public void ShouldBeFutureDates()
        {
            var response = JArray.Parse(JsonConvert.SerializeObject(_scenarioContext["ForecastResponseData"]));
            var forecasts = response.ToObject<List<WeatherForecast>>();

            foreach (var f in forecasts)
            {
                Assert.True(f.Date > DateTime.Now);
            }
        }

        [Then(@"celsius temparature and fahrenheit temparature should match")]
        public void TemparaturesShouldMatch()
        {
            var response = JArray.Parse(JsonConvert.SerializeObject(_scenarioContext["ForecastResponseData"]));
            var forecasts = response.ToObject<List<WeatherForecast>>();

            foreach (var f in forecasts)
            {
                var temperatureF = 32 + (int)(f.TemperatureC / 0.5556);
                Assert.AreEqual(f.TemperatureF, temperatureF);
            }
        }

        [Then(@"should get a correct summary")]
        public void ShouldGetCorrectSummary()
        {
            var summaries = new List<string>() { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };

            var response = JArray.Parse(JsonConvert.SerializeObject(_scenarioContext["ForecastResponseData"]));
            var forecasts = response.ToObject<List<WeatherForecast>>();

            foreach (var f in forecasts)
            {
                Assert.Contains(f.Summary, summaries);
            }            
        }

    }
}