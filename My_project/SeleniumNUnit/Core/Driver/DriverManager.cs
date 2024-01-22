using OpenQA.Selenium;

namespace SeleniumNUnit.Core.Driver
{
    public abstract class DriverManager
    {
        protected static IWebDriver? driver;
        protected abstract IWebDriver CreateDriver();

        public IWebDriver GetDriver()
        {
            if (driver == null) 
            {
                try
                {
                    driver = CreateDriver();
                }
                catch (Exception e)
                {
                    NLog.LogManager.GetCurrentClassLogger().Error(e, "Unable to create driver!");
                }
                NLog.LogManager.Shutdown();
            }
            return driver;
        }
    }
}