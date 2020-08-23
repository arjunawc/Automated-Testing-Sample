using TechTalk.SpecFlow;

namespace AutomationTests.Hooks
{
    [Binding]
    public class BeforeAfterStep
    {
        [BeforeStep]
        public static void BeforeStepRun()
        {
        }

        [AfterStep]
        public static void AfterStepRun()
        {
        }
    }
}
