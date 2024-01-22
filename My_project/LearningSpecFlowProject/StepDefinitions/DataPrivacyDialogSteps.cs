using LearningSpecFlowProject.Dialogs;

namespace LearningSpecFlowProject.StepDefinitions
{
    [Binding]
    public sealed class DataPrivacyDialogSteps
    {
        [When(@"I close Data Privacy pop up")]
        public void CloseDataPrivacyPopUp()
        {
            DataPrivacyDialog.Instance.ScrollToAcceptAllButton();
            DataPrivacyDialog.Instance.CloseDataPrivacyPopUp();
        }
    }
}