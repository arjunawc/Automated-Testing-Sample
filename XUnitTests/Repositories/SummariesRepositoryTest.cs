using Automatted_Testing_Sample.Repositories;
using System.Linq;
using Xunit;

namespace XUnitTests.Repositories
{
    public class SummariesRepositoryTest
    {
        private readonly ISummaries _summaries;

        public SummariesRepositoryTest()
        {
            _summaries = new Summaries();            
        }

        [Fact]
        public void Summaries_ShouldReturn_WeatherSummaries()
        {
            // Act
            var result = _summaries.WeatherSummaries;

            // Assert
            Assert.True(result.Any());
        }
    }
}
