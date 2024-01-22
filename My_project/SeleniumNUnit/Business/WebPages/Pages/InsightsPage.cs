using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using NLog;

namespace SeleniumNUnit.Business.WebPages.Pages
{
    public class InsightsPage : BasePage
    {
        public const string pageIdentifier = "Insights";

        private readonly By carouselTitleXpath = By.XPath("//*[@class='content-container parsys']//div[@class='slider section'][1]//div[@class='owl-item active']//p");
        private readonly By readMoreLinkXpath = By.XPath("//*[@class='content-container parsys']//div[@class='slider section'][1]//div[@class='owl-item active']//div[@data-link-name='Read More']//a");
        private readonly By headerSectionHamburgerMenuXpath = By.XPath("//div[@class='hamburger-menu-ui hamburger-menu-ui-23']");
        public InsightsPage (IWebDriver driver) : base(driver) { }

        public void SwipeCarousel()
        {
            LogManager.GetCurrentClassLogger().Trace("Attempting to swipe the carousel");
            var carouselTitle = _driver.FindElement(carouselTitleXpath);
            new WebDriverWait(_driver, TimeSpan.FromSeconds(20)).Until(d => carouselTitle.Displayed);
            var headerSectionHamburgerMenu = _driver.FindElement(headerSectionHamburgerMenuXpath);
            new Actions(_driver).DragAndDrop(carouselTitle, headerSectionHamburgerMenu).Release().Perform();
            new Actions(_driver).Pause(TimeSpan.FromSeconds(3)).Perform();
            LogManager.GetCurrentClassLogger().Info("Swiped the carousel");
        }

        public string GetArticleName()
        {
            LogManager.GetCurrentClassLogger().Trace("Attempting to get Article Name");
            var carouselTitle = _driver.FindElement(carouselTitleXpath);
            string articleName = carouselTitle.Text;
            LogManager.GetCurrentClassLogger().Info("Got Article Name");
            return articleName;
        }

        public BlogsPage ClickReadMoreLink()
        {
            LogManager.GetCurrentClassLogger().Trace("Attempting to click Read More link");
            var readMoreLink = _driver.FindElement(readMoreLinkXpath);
            readMoreLink.Click();
            LogManager.GetCurrentClassLogger().Info("Clicked Read More link");
            return new BlogsPage(_driver);
        }
    }
}