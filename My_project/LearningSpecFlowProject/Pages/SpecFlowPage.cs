using OpenQA.Selenium;
using SpecFlowCore.Extentions;

namespace LearningSpecFlowProject.Pages
{
    public class SpecFlowPage : GeneralPage
    {
        private By searchDocsInputFieldXpath = By.XPath("//form[@id='rtd-search-form']/input[@name='q']");

        private static SpecFlowPage? specFlowPage;
        public static new SpecFlowPage Instance => specFlowPage ?? new SpecFlowPage();

        public void ClickSearchDocsInputField()
        {
            driver.IsDisplayed(searchDocsInputFieldXpath, 20);
            var searchDocsInputField = driver.FindElement(searchDocsInputFieldXpath);
            searchDocsInputField.Click();
        }
    }
}