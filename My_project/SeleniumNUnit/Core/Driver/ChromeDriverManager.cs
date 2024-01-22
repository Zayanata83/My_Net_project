using OpenQA.Selenium.Chrome;
using System.Configuration;
using SeleniumNUnit.Configurations.AppConfigurations;
using OpenQA.Selenium;

namespace SeleniumNUnit.Core.Driver
{
    public class ChromeDriverManager : DriverManager
    {
        protected override IWebDriver CreateDriver()
        {
            Configuration configuration = AppConfiguration.GetConfiguration();
            var isHeadless = Convert.ToBoolean(configuration.AppSettings.Settings["headlessMode"].Value);
            if (isHeadless)
            {
                ChromeOptions option = new ChromeOptions();
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
                option.AddUserProfilePreference("download.prompt_for_download", false);
                option.AddUserProfilePreference("safebrowsing", "enabled");
                option.AddUserProfilePreference("disable-popup-blocking", "true");
                driver = new ChromeDriver(option);
                return driver;
            }
            else
            {
                driver = new ChromeDriver();
                return driver;
            }
        }
    }
}