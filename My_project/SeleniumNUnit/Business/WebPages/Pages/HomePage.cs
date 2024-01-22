using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using NLog;

namespace SeleniumNUnit.Business.WebPages.Pages
{
    public class HomePage : BasePage
    {
        private readonly By oneTrustHandler = By.Id("onetrust-accept-btn-handler");
        public HomePage(IWebDriver driver) : base(driver) { }

        public void CloseHandlerPopup()
        {
            LogManager.GetCurrentClassLogger().Trace("Attempting to close oneTrustHundler");
            var handlerPopup = _driver.FindElement(oneTrustHandler);
            new WebDriverWait(_driver, TimeSpan.FromSeconds(30)).Until(d => handlerPopup.Displayed);
            handlerPopup.Click();
            LogManager.GetCurrentClassLogger().Info("Closed oneTrustHundler");
        }
    }
}