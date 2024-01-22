using OpenQA.Selenium;
using SeleniumNUnit.Business.WebPages.Pages;

namespace SeleniumNUnit.Business.WebPages
{
    public class PageFactory
    {
        public static BasePage InitPage (string identifier, IWebDriver driver) 
        {
            switch (identifier)
            {
                case AboutPage.pageIdentifier:
                    return new AboutPage(driver);
                case CareersPage.pageIdentifier:
                    return new CareersPage(driver);
                case InsightsPage.pageIdentifier:
                    return new InsightsPage(driver);
                default:
                    throw new ArgumentException();
            }
        }
    }
}