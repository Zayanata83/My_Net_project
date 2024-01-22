using OpenQA.Selenium;
using SpecFlowCore.Drivers;
using SpecFlowCore.Extentions;

namespace LearningSpecFlowProject.Pages
{
    public class GeneralPage
    { 
        private string TitleXPath => "//h1[contains(. , '{0}')]";

        public IWebDriver driver = DriverManager.Instance();

        private static GeneralPage? basePage;
        public static GeneralPage Instance => basePage ?? new GeneralPage();

        public bool IsPageTitleDisplayed(string pageTitle)
        {
            return driver.IsDisplayed(By.XPath(string.Format(TitleXPath, pageTitle)));
        }
    }
}