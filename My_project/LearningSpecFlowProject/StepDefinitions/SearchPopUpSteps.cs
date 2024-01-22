using LearningSpecFlowProject.Dialogs;

namespace LearningSpecFlowProject.StepDefinitions
{
    [Binding]
    public sealed class SearchPopUpSteps
    {
        [When(@"I click Search input field on SearchPopup")]
        public void ClickSearchInputFieldOnSearchPopup()
        {
            SearchPopup.Instance.ClickSearchInputField();
        }

        [When(@"I enter '([^']*)' into Search input field on SearchPopup")]
        public void EnterIntoSearchInputFieldOnSearchPopup(string installation)
        {
            SearchPopup.Instance.EnterSearchDataIntoSearchInputField(installation);
        }

        [When(@"I click first search result on Search popup")]
        public void ClickFirstSearchResultOnSearchPopup()
        {
            SearchPopup.Instance.ClickFirstSearchResult();
        }
    }
}