using OpenQA.Selenium;
using OpenQA.Selenium.Safari;

namespace SeleniumNUnit.Core.Driver
{
    public class SafariDriverManager : DriverManager
    {
        protected override IWebDriver CreateDriver()
        {
            driver = new SafariDriver();
            return driver;
        }
    }
}