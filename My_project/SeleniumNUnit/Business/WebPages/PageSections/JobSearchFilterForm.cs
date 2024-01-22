using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumNUnit.Business.WebPages.Pages;
using NLog;

namespace SeleniumNUnit.Business.WebPages.PageSections
{
    public class JobSearchFilterForm : BasePage
    {
        private string locationDropDownItemString = "//ul[@class='select2-results__options select2-results__options--nested']/li[contains(. , '{0}')]";

        private readonly By keyWordFieldId = By.Id("new_form_job_search-keyword");
        private readonly By locationFieldClassName = By.ClassName("recruiting-search__location");
        private readonly By remoteCheckboxXpath = By.XPath("//input[@name='remote']/ancestor::p");
        private readonly By findButtonSelector = By.CssSelector("button.job-search-button-transparent-23");

        public JobSearchFilterForm(IWebDriver driver) : base(driver) { }

        public void EnterSearchKeyword(string serchKeyword)
        {
            LogManager.GetCurrentClassLogger().Trace("Attempting to enter search keyword");
            var keyWordField = _driver.FindElement(keyWordFieldId);
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(d => keyWordField.Enabled);
            keyWordField.SendKeys(serchKeyword);
            LogManager.GetCurrentClassLogger().Info("Entered search keyword");
        }

        public void ClickLocation()
        {
            LogManager.GetCurrentClassLogger().Trace("Attempting to click Location");
            var locationField = _driver.FindElement(locationFieldClassName);
            new WebDriverWait(_driver, TimeSpan.FromSeconds(20)).Until(d => locationField.Enabled);
            locationField.Click();
            LogManager.GetCurrentClassLogger().Info("Clicked Location");
        }

        public void SelectLocationFromList(string location)
        {
            LogManager.GetCurrentClassLogger().Trace("Attempting to select Location from list");
            var locationPlaceField = _driver.FindElement(By.XPath(String.Format(locationDropDownItemString, location)));
            new WebDriverWait(_driver, TimeSpan.FromSeconds(20)).Until(l => locationPlaceField.Enabled);
            locationPlaceField.Click();
            LogManager.GetCurrentClassLogger().Info("Selected Location from List");
        }

        public void ClickRemoteJobCheckbox()
        {
            LogManager.GetCurrentClassLogger().Trace("Attempting to click Remote Job checkbox");
            var remoteCheckbox = _driver.FindElement(remoteCheckboxXpath);
            remoteCheckbox.Click();
            LogManager.GetCurrentClassLogger().Info("Clicked Remote Job checkbox");
        }
        public JoinOurTeamPage ClickFindButton()
        {
            LogManager.GetCurrentClassLogger().Trace("Attempting to click Find button");
            var findButton = _driver.FindElement(findButtonSelector);
            findButton.Click();
            LogManager.GetCurrentClassLogger().Trace("Clicked Find button");
            return new JoinOurTeamPage(_driver);
        }
    }
}