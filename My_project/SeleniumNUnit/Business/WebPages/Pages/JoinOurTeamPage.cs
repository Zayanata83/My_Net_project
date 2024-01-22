using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using NLog;

namespace SeleniumNUnit.Business.WebPages.Pages
{
    public class JoinOurTeamPage : BasePage
    {
        private readonly By jobTitleXpath = By.XPath("(//ul[@class='search-result__list']/li[@class='search-result__item'])[1]//h5");
        private readonly By dateLabelXpath = By.XPath("//li[@title='Date']");
        private readonly By viewAndApplyButtonXpath = By.XPath("(//ul[@class='search-result__list']/li[@class='search-result__item'])[1]//a[contains(. , 'View')][1]");

        public JoinOurTeamPage(IWebDriver driver) : base(driver) { }

        public string GetFirstProposedJobTitle() => _driver.FindElement(jobTitleXpath).Text;

        public void ClickDateFilter()
        {
            LogManager.GetCurrentClassLogger().Trace("Attempting to click Date Filter");
            var dateLabel = _driver.FindElement(dateLabelXpath);
            new WebDriverWait(_driver, TimeSpan.FromSeconds(20)).Until(d => dateLabel.Displayed);
            dateLabel.Click();
            LogManager.GetCurrentClassLogger().Info("Clicked Date Filter");
        }

        public void MoveToViewAndApplyButton(string lastTitle)
        {
            LogManager.GetCurrentClassLogger().Trace("Attempting to move to View and Apply button");
            new Actions(_driver).MoveToLocation(0, 2000);
            new WebDriverWait(_driver, TimeSpan.FromSeconds(20)).Until(d => _driver.FindElement(jobTitleXpath).Text != lastTitle);
            var viewAndApplyButton = _driver.FindElement(viewAndApplyButtonXpath);
            new Actions(_driver).MoveToElement(viewAndApplyButton);
            LogManager.GetCurrentClassLogger().Info("Moved to View and Apply button");
        }

        public JobDetailsPage ClickViewAndApplyButton()
        {
            LogManager.GetCurrentClassLogger().Trace("Attempting to click View and Apply button");
            var viewAndApplyButton = _driver.FindElement(viewAndApplyButtonXpath);
            viewAndApplyButton.Click();
            LogManager.GetCurrentClassLogger().Trace("Clicked View and Apply button");
            return new JobDetailsPage(_driver);
        }
    }
}