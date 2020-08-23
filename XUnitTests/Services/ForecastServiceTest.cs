using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using XUnitTests.Data;

namespace XUnitTests.Services
{
    public class ForecastServiceTest : IClassFixture<ForecastServiceFixture>
    {
        private readonly ForecastServiceFixture _forecastServiceFixture;

        private int recordReturnCount;
        private int temperatureF;

        public ForecastServiceTest(ForecastServiceFixture forecastServiceFixture)
        {
            _forecastServiceFixture = forecastServiceFixture;
        }

        [Theory]
        [WeatherSummaryData]
        public void Get_ShouldReturn_CorrentWeatherForecastSummary(string weatherSummary)
        {
            // Arrange
            _forecastServiceFixture.SummariesMock.Setup(s => s.WeatherSummaries).Returns(new List<string>() { weatherSummary });
            _forecastServiceFixture.WeatherMock.Setup(w => w.GetTemperature(It.IsAny<int>())).Returns(It.IsAny<int>);

            // Act
            var result = _forecastServiceFixture.Forecast.Get();

            // Assert
            Assert.Equal(weatherSummary, result.First().Summary);
        }

        [Theory]
        [TemperatureCData]
        public void Get_ShouldReturn_CorrentWeatherForecastTemperatureC(int temperatureC)
        {
            // Arrange
            _forecastServiceFixture.WeatherMock.Setup(w => w.GetTemperature(It.IsAny<int>())).Returns(temperatureC);
            _forecastServiceFixture.SummariesMock.Setup(s => s.WeatherSummaries).Returns(new List<string>() { It.IsAny<string>() });

            // Act
            var result = _forecastServiceFixture.Forecast.Get();

            // Assert
            Assert.Equal(temperatureC, result.First().TemperatureC);
        }

        [Theory]
        [TemperatureCData]
        public void Get_ShouldReturn_CorrentWeatherForecastTemperatureF(int temperatureC)
        {
            // Arrange
            temperatureF = 32 + (int)(temperatureC / 0.5556);
            _forecastServiceFixture.WeatherMock.Setup(w => w.GetTemperature(It.IsAny<int>())).Returns(temperatureC);
            _forecastServiceFixture.SummariesMock.Setup(s => s.WeatherSummaries).Returns(new List<string>() { It.IsAny<string>() });

            // Act
            var result = _forecastServiceFixture.Forecast.Get();

            // Assert
            Assert.Equal(temperatureF, result.First().TemperatureF);
        }

        [Fact]
        public void Get_ShouldReturn_CorrentWeatherForecastNumberOfDays()
        {
            // Arrange
            recordReturnCount = 5;
            _forecastServiceFixture.SummariesMock.Setup(s => s.WeatherSummaries).Returns(new List<string>() { It.IsAny<string>() });
            _forecastServiceFixture.WeatherMock.Setup(w => w.GetTemperature(It.IsAny<int>())).Returns(It.IsAny<int>);

            // Act
            var result = _forecastServiceFixture.Forecast.Get();

            // Assert
            Assert.Equal(recordReturnCount, result.Count());
        }

        [Fact]
        public void Get_ShouldReturn_CorrentWeatherForecastDate()
        {
            // Arrange
            _forecastServiceFixture.SummariesMock.Setup(s => s.WeatherSummaries).Returns(new List<string>() { It.IsAny<string>() });
            _forecastServiceFixture.WeatherMock.Setup(w => w.GetTemperature(It.IsAny<int>())).Returns(It.IsAny<int>);

            // Act
            var result = _forecastServiceFixture.Forecast.Get();

            // Assert
            Assert.True(DateTime.Now < result.First().Date);
        }
    }
}
