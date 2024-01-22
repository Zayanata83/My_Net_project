using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace SpecFlowCore.Extentions
{
    public static class BaseDriverExtention
    {
        public static bool IsDisplayed(this IWebDriver driver,  By locator, int timeout = 20)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(d => driver.FindElement(locator).Displayed);
        }
    }
}