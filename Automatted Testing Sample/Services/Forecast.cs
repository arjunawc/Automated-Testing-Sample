using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Automatted_Testing_Sample.Repositories;

namespace Automatted_Testing_Sample.Services
{
    public class Forecast : IForecast
    {
        private readonly ISummaries m_summaries;

        private readonly IWeather m_weather;

        public Forecast(ISummaries summaries, IWeather weather)
        {
            m_summaries = summaries;
            m_weather = weather;
        }
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = m_weather.GetTemperature(index),
                    Summary = m_summaries.WeatherSummaries[rng.Next(m_summaries.WeatherSummaries.Count)]
                })
                .ToArray();
        }
    }
}
