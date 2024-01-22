using OpenQA.Selenium;
using SeleniumNUnit.Business.WebPages.PageSections;

namespace SeleniumNUnit.Business.WebPages.Pages
{
    public class CareersPage : BasePage
    {
        public const string pageIdentifier = "Careers";
        public JobSearchFilterForm jobSearchFilterForm;

        public CareersPage(IWebDriver driver) : base(driver)
        {
            jobSearchFilterForm = new JobSearchFilterForm(_driver);
        }
    }
}