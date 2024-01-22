using System.Configuration;
using SeleniumNUnit.Configurations.AppConfigurations;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;

namespace SeleniumNUnit.Core.Driver
{
    public class FirefoxDriverManager : DriverManager
    {
        protected override IWebDriver CreateDriver()
        {
            Configuration configuration = AppConfiguration.GetConfiguration();
            var isHeadless = Convert.ToBoolean(configuration.AppSettings.Settings["headlessMode"].Value);
            if (isHeadless)
            {
                FirefoxOptions option = new FirefoxOptions();
                option.AddArguments(new List<string>()
            {
                "--silent-launch",
                "--no-startup-window",
                "no-sandbox",
                "--headless"
            });
                option.AddArgument("--disable-extensions");
                option.AddArgument("--safebrowsing-disable-download-protection");
                option.AddArgument("enable-automation");
                option.AddArgument("test-type=browser");
               
                driver = new FirefoxDriver(option);
                return driver;
            }
            else
            {
                driver = new FirefoxDriver();
                return driver;
            }
        }
    }
}