using NLog;
using OpenQA.Selenium;

namespace SeleniumNUnit.Core.Extentions
{
    public static class PageDataExtention
    {
        public static bool IsPageSourceContainData(this IWebDriver driver, string text)
        {
            LogManager.GetCurrentClassLogger().Trace("Attempting to check if page contains text");
            return driver.PageSource.Contains(text);
        }
    }
}