using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using NLog;

namespace SeleniumNUnit.Business.WebPages.Pages
{
    public class AboutPage : BasePage
    {
        public const string pageIdentifier = "About";
        private readonly By downloadButtonXpath = By.XPath("//*[@class='button']//a[@class='button-ui-23 btn-focusable']//span[contains(. , 'DOWNLOAD')][@class='button__inner']");
        public AboutPage(IWebDriver driver) : base(driver) { }

        public void ScrollToDownloadButton()
        {
            LogManager.GetCurrentClassLogger().Trace("Scrolling to Download Button");
            var downloadButton = _driver.FindElement(downloadButtonXpath);
            new WebDriverWait(_driver, TimeSpan.FromSeconds(20)).Until(d => downloadButton.Enabled);
            new Actions(_driver).ScrollToElement(downloadButton).Perform();
            LogManager.GetCurrentClassLogger().Info("Scrolled to Download Button");
        }

        public void ClickDownloadButton()
        {
            LogManager.GetCurrentClassLogger().Trace("Try to click Download Button");
            string Path = Environment.GetEnvironmentVariable("USERPROFILE") + "\\Downloads";
            var filePaths = Directory.GetFiles(Path).ToList();
            var downloadButton = _driver.FindElement(downloadButtonXpath);

            new WebDriverWait(_driver, TimeSpan.FromSeconds(5)).Until(d => downloadButton.Enabled);
            downloadButton.Click();
            LogManager.GetCurrentClassLogger().Info("Clicked Download Button");
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(d => Directory.GetFiles(Path).Count() != filePaths.Count);
        }
    }
}