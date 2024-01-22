using LearningSpecFlowProject.Pages;
using NUnit.Framework;

namespace LearningSpecFlowProject.StepDefinitions
{
    [Binding]
    public sealed class GeneralSteps
    {
        [Given(@"I open official SpecFlow web site")]
        public void OpenOfficialSpecFlowWebSite()
        {
            HomePage.Instance.OpenSpecFlowHomePage();
        }

        [Then(@"Page with '(.*)' title should be opened")]
        public void PageWithTitleShouldBeOpened(string title)
        {
            Assert.IsTrue(GeneralPage.Instance.IsPageTitleDisplayed(title), $"Page title - {title} for the page is not displayed");
        }
    }
}