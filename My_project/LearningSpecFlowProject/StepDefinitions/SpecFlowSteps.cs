using LearningSpecFlowProject.Pages;

namespace LearningSpecFlowProject.StepDefinitions
{
    [Binding]
    public sealed class SpecFlowSteps
    {
        [When(@"I click Search Docs input field on SpecFlow page")]
        public void ClickSearchDocsInputFieldOnSpecFlowPage()
        {
            SpecFlowPage.Instance.ClickSearchDocsInputField();
        }
    }
}