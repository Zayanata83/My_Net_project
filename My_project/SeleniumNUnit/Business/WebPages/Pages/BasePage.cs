using OpenQA.Selenium;

namespace SeleniumNUnit.Business.WebPages.Pages
{
    public abstract class BasePage
    {
        protected static IWebDriver _driver;

        public BasePage(IWebDriver driver) => _driver = driver;
    }
}