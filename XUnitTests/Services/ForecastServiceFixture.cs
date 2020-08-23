using Automatted_Testing_Sample.Repositories;
using Automatted_Testing_Sample.Services;
using Moq;
using System;

namespace XUnitTests.Services
{
    public class ForecastServiceFixture : IDisposable
    {
        public Forecast Forecast { get; private set; }
        public Mock<ISummaries> SummariesMock { get; private set; }
        public Mock<IWeather> WeatherMock { get; private set; }

        public ForecastServiceFixture()
        {
            WeatherMock = new Mock<IWeather>();
            SummariesMock = new Mock<ISummaries>();
            Forecast = new Forecast(SummariesMock.Object, WeatherMock.Object);
        }

        public void Dispose()
        {
            // Cleanup            
        }
    }
}
