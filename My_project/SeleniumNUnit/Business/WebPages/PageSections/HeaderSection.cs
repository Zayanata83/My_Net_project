using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumNUnit.Business.WebPages.Pages;
using SeleniumNUnit.Business.BusinessEnums;
using NLog;

namespace SeleniumNUnit.Business.WebPages.PageSections
{
    public class HeaderSection : BasePage
    {
        private readonly By hamburgerMenuXpath = By.XPath("//div[@class='hamburger-menu-ui hamburger-menu-ui-23']/button");
        private readonly By searchIconSelector = By.CssSelector(".header__icon");
        private readonly By findButtonXpath = By.XPath("//*[@class='search-results__action-section']//button");
        private readonly By searchFieldSelector = By.Name("q");

        public HeaderSection(IWebDriver driver) : base(driver) { }

        public void ClickHamburgerMenu()
        {
            LogManager.GetCurrentClassLogger().Trace("Attempting to click hamburger menu");
            var hamburgerMenu = _driver.FindElement(hamburgerMenuXpath);
            new WebDriverWait(_driver, TimeSpan.FromSeconds(20)).Until(d => hamburgerMenu.Displayed);
            hamburgerMenu.Click();
            LogManager.GetCurrentClassLogger().Info("Clicked Hamburger menu");
        }

        public BasePage ClickExpandedHamburgerMenuItem(HeaderHamburgerMenu menuItem)
        {
            LogManager.GetCurrentClassLogger().Trace("Attempting to click expanded Hamburger Menu Item");
            var careersLabel = _driver.FindElement(By.LinkText(menuItem.ToString()));
            careersLabel.Click();
            LogManager.GetCurrentClassLogger().Info("Clicked expanded Hamburger Menu Item");
            return PageFactory.InitPage(menuItem.ToString(), _driver);
        }

        public void ClickSearchIcon()
        {
            LogManager.GetCurrentClassLogger().Trace("Attempting to click Search Icon");
            var searchIcon = _driver.FindElement(searchIconSelector);
            searchIcon.Click();
            LogManager.GetCurrentClassLogger().Info("Clicked Search Icon");
        }

        public void EnterSearchWord(string searchData)
        {
            LogManager.GetCurrentClassLogger().Trace("Attempting to enter search word");
            var searchField = _driver.FindElement(searchFieldSelector);
            new WebDriverWait(_driver, TimeSpan.FromSeconds(20)).Until(d => searchField.Displayed);
            searchField.Clear();
            searchField.SendKeys(searchData);
            LogManager.GetCurrentClassLogger().Info("Entered Search Word");
        }

        public SearchPage ClickFindButton()
        {
            LogManager.GetCurrentClassLogger().Trace("Attempting to click Find button");
            var findButton = _driver.FindElement(findButtonXpath);
            findButton.Click();
            LogManager.GetCurrentClassLogger().Info("Clicked Find button");
            return new SearchPage(_driver);
        }
    }
}