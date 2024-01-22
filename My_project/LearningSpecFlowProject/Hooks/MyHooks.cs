using BoDi;
using OpenQA.Selenium;
using SpecFlowCore.Drivers;

namespace LearningSpecFlowProject.Hooks
{
    [Binding]
    public sealed class MyHooks
    {
        private readonly IObjectContainer _container;

        public MyHooks(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeScenario("@Smoke")]
        public void BeforeScenarioWithTag()
        {
            Console.WriteLine("Running inside smoke tag");
        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {
            IWebDriver driver = DriverManager.Instance();
            _container.RegisterInstanceAs<IWebDriver>(driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var driver = _container.Resolve<IWebDriver>();

            if (driver != null)
            {
                driver.Quit();
            }
        }
    }
}