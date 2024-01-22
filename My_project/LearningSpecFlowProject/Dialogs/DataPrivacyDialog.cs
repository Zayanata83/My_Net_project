using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace LearningSpecFlowProject.Dialogs
{
    public class DataPrivacyDialog : BaseDialog
    {
        private By acceptAllButtonXpath => By.XPath("//button[@id='consent-accept']");

        private static DataPrivacyDialog? dataPrivacyDialog;
        public static new DataPrivacyDialog Instance => dataPrivacyDialog ?? new DataPrivacyDialog();

        public void ScrollToAcceptAllButton()
        {
            IsPageTitleDisplayed("Data Privacy");
            var actions = new Actions(driver);
            actions.ScrollToElement(driver.FindElement(acceptAllButtonXpath)).Perform();
            
        }
        public void CloseDataPrivacyPopUp()
        {
            var acceptAllButton = driver.FindElement(acceptAllButtonXpath);
            acceptAllButton.Click();
        }
    }
}