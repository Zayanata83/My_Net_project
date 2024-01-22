using NLog;
using OpenQA.Selenium;

namespace SeleniumNUnit.Business.WebPages.Pages
{
    public class SearchPage : BasePage
    {
        private readonly By serchResultLinksXpath = By.XPath("//*[@class='search-results__items']/article[@class='search-results__item']//a");
        public SearchPage (IWebDriver driver) : base(driver) { }

        public bool AreAllLinksContainText(string data)
        {
            LogManager.GetCurrentClassLogger().Trace("Attempting to know or all links contain text");
            var searchResultsLinks = _driver.FindElements(serchResultLinksXpath);
            try
            {
                return searchResultsLinks.All(x => x.Text.ToLower().Contains(data.ToLower()));
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex, "Unable to check if all links contain text");
                return false;
            }
        }
    }
}