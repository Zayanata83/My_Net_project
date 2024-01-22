using NLog;
using OpenQA.Selenium;
using SeleniumNUnit.Business.WebPages.Pages;
using SeleniumNUnit.Configurations.AppConfigurations;

namespace SeleniumNUnit.Tests.Utils
{
    public static class AppUtilities
    {
        public static void OpenApplication(IWebDriver driver)
        {
            LogManager.GetCurrentClassLogger().Trace("Opening Application");
            string site = AppConfiguration.GetConfiguration().AppSettings.Settings["mySite"].Value;
            driver.Navigate().GoToUrl(site);

            LogManager.GetCurrentClassLogger().Info($"Opened url => {site}");
            HomePage homePage = new HomePage(driver);
            homePage.CloseHandlerPopup();
            LogManager.GetCurrentClassLogger().Info("Closed HandlerPopup");
        }

        public static void CloseBrowser(IWebDriver driver)
        {
            LogManager.GetCurrentClassLogger().Trace("Closing Browser");
            driver.Close();
            driver.Quit();
        }
    }
}
