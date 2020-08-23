using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace XUnitTests.Data
{
    public class TemperatureCData : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { -20 };
            yield return new object[] { -1 };
            yield return new object[] { 0 };
            yield return new object[] { 5 };
            yield return new object[] { 15 };
            yield return new object[] { 25 };
        }
    }
}
