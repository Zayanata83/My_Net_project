using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowCore.Extentions;

namespace LearningSpecFlowProject.Dialogs
{
    public class SearchPopup : BaseDialog
    {
        private By searchInputFieldXpath = By.XPath("//input[@class='search__outer__input']");
        private By searchResultXpath = By.XPath("//div[@class='search__result__box']/div[@class='search__result__single']//span[@class='search__result__subheading']");

        private static SearchPopup? searchPopUp;
        public static new SearchPopup Instance => searchPopUp ?? new SearchPopup();

        public void ClickSearchInputField()
        {
            driver.IsDisplayed(searchInputFieldXpath, 20);
            var searchInputField = driver.FindElement(searchInputFieldXpath);
            searchInputField.Click();
        }

        public void EnterSearchDataIntoSearchInputField(string data)
        {
            var searchInputField = driver.FindElement(searchInputFieldXpath);
            searchInputField.SendKeys(data);
        }

        public void ClickFirstSearchResult()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(d => driver.FindElements(searchResultXpath).Any());
            var firstSearchResult = driver.FindElements(searchResultXpath).First();
            firstSearchResult.Click();
        }
    }
}