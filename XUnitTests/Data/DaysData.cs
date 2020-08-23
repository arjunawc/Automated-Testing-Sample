using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace XUnitTests.Data
{
    public class DaysData : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { 1 };
            yield return new object[] { 9 };
            yield return new object[] { 10 };
            yield return new object[] { 15 };
            yield return new object[] { 18 };
            yield return new object[] { 25 };
            yield return new object[] { 30 };
        }
    }
}
