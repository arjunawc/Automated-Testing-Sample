using Automatted_Testing_Sample.Controllers;
using Automatted_Testing_Sample.Repositories;
using Automatted_Testing_Sample.Services;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace XUnitTests.Controllers
{
    public class WeatherForecastControllerTest
    {
        private Forecast _forecast;
        private Mock<ISummaries> _summariesMock;
        private Mock<IWeather> _weatherMock;
        private Mock<ILogger<WeatherForecastController>> _loggerMock;
        private WeatherForecastController _weatherForecastController;

        public WeatherForecastControllerTest()
        {
            _loggerMock = new Mock<ILogger<WeatherForecastController>>();
            _weatherMock = new Mock<IWeather>();
            _summariesMock = new Mock<ISummaries>();
            _forecast = new Forecast(_summariesMock.Object, _weatherMock.Object);
            _weatherForecastController = new WeatherForecastController(_loggerMock.Object, _forecast);
        }

        [Fact]
        public void Get_ShouldReturn_WeatherForecastCollection()
        {
            // Arrange
            _summariesMock.Setup(s => s.WeatherSummaries).Returns(new List<string>() { It.IsAny<string>() });
            _weatherMock.Setup(w => w.GetTemperature(It.IsAny<int>())).Returns(It.IsAny<int>);

            // Act
            var result = _weatherForecastController.Get();

            // Assert
            Assert.True(result.Any());
        }
    }
}
