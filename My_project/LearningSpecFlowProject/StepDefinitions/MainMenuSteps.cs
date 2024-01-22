using LearningSpecFlowProject.Pages;

namespace LearningSpecFlowProject.StepDefinitions
{
    [Binding]
    public sealed class MainMenuSteps
    {
        [When(@"I hover the '(.*)' menu item from the main menu")]
        public void HoverTheMenuItemFromTheMainMenu(string menuItem)
        {
            HomePage.Instance.HoverMainMenuItem(menuItem);
        }

        [When(@"I click '(.*)' option from the main menu")]
        public void ClickOptionFromTheMainMenu(string option)
        {
            HomePage.Instance.ClickSubMenuItem(option);
        }
    }
}