using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using NLog;

namespace SeleniumNUnit.Business.WebPages.Pages
{
    public class BlogsPage : BasePage
    {
        private readonly By articleNameXpath = By.XPath("//div[@class='container detail-page23__container  ']//div[@class='top-upper-part']//span[@class='museo-sans-light']");
        public BlogsPage(IWebDriver driver) : base(driver) { }

        public string GetArticleName()
        {
            LogManager.GetCurrentClassLogger().Trace("Try to get Article Name");
            var articleName = _driver.FindElement(articleNameXpath);
            new WebDriverWait(_driver, TimeSpan.FromSeconds(5)).Until(d => articleName.Displayed);
            LogManager.GetCurrentClassLogger().Info("Got Article Name");
            return articleName.Text;
        }
    }
}