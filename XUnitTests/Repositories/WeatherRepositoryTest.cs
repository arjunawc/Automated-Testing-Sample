using Automatted_Testing_Sample.Repositories;
using Xunit;
using XUnitTests.Data;

namespace XUnitTests.Repositories
{
    public class WeatherRepositoryTest
    {
        private readonly IWeather _weather;
        private const int MINTEMP = -20;
        private const int MAXTEMP = 55;

        public WeatherRepositoryTest()
        {
            _weather = new Weather();
        }

        [Theory]
        [DaysData]
        public void GetTemperature_ShouldReturn_TemperatureWithinRange(int day)
        {
            // Act
            var result = _weather.GetTemperature(day);

            // Assert
            Assert.InRange(result, MINTEMP, MAXTEMP);
        }
    }
}
