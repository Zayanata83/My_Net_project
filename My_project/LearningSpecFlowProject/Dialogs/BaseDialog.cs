using OpenQA.Selenium;
using SpecFlowCore.Drivers;
using SpecFlowCore.Extentions;

namespace LearningSpecFlowProject.Dialogs
{
    public class BaseDialog
    {
        private static string TitleXpath => "//h2[contains(. , '{0}')]";

        public IWebDriver driver = DriverManager.Instance();

        private static BaseDialog? baseDialog;
        public static BaseDialog Instance => baseDialog ?? new BaseDialog();

        public bool IsPageTitleDisplayed(string pageTitle)
        {
            return driver.IsDisplayed(By.XPath(string.Format(TitleXpath, pageTitle)));
        }
    }
}