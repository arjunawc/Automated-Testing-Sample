using TechTalk.SpecFlow;

namespace AutomationTests.Hooks
{
    [Binding]
    public sealed class BeforeAfterScenario
    {
        private readonly ScenarioContext _scenarioContext;

        public BeforeAfterScenario(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _scenarioContext.Clear();
        }
    }
}
