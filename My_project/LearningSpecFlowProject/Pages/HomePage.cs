using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using LearningSpecFlowProject.AppConfigurations;
using SpecFlowCore.Drivers;

namespace LearningSpecFlowProject.Pages
{
    public class HomePage : GeneralPage
    {
        private By MainMenuItemXpath => By.XPath("//ul[@id='menu-main-navigation']/li/a");
        private By SubMenuItemXpath => By.XPath("//ul[@class='sub-menu']/li/a");

        private static HomePage? homePage;
        public static new HomePage Instance => homePage ?? new HomePage();

        public void OpenSpecFlowHomePage()
        {
            string site = AppConfig.GetConfiguration().AppSettings.Settings["mySite"].Value;
            DriverManager.Instance().Navigate().GoToUrl(site);
        }

        public void HoverMainMenuItem(string item)
        {
            var actions = new Actions(driver);
            var menuItem = driver.FindElements(MainMenuItemXpath).First(x => x.Text.Equals(item));
            actions.MoveToElement(menuItem).Perform();
        }

        public void ClickSubMenuItem(string item)
        {
            var subMenuItem = driver.FindElements(SubMenuItemXpath).First(x => x.Text.Equals(item));
            subMenuItem.Click();
        }
    }
}