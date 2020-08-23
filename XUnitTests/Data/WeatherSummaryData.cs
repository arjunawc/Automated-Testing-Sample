using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace XUnitTests.Data
{
    public class WeatherSummaryData : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { "Freezing" };
            yield return new object[] { "Bracing" };
            yield return new object[] { "Chilly" };
            yield return new object[] { "Cool" };
            yield return new object[] { "Mild" };
            yield return new object[] { "Warm" };
            yield return new object[] { "Balmy" };
            yield return new object[] { "Hot" };
            yield return new object[] { "Sweltering" };
            yield return new object[] { "Scorching" };
        }
    }
}
