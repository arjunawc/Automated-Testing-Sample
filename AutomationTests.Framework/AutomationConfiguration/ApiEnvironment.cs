namespace AutomationTests.Framework.AutomationConfiguration
{
    public class ApiEnvironment
    {
        public static string BaseUrl { get; private set; }


        public static void Init()
        {
            BaseUrl = "https://localhost:5001/";
        }
    }
}
