using AutomationTests.Framework.AutomationConfiguration;
using TechTalk.SpecFlow;

namespace AutomationTests.Hooks
{
    [Binding]
    public sealed class BeforAfterTest
    {

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            ApiEnvironment.Init();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
        }
    }
}
