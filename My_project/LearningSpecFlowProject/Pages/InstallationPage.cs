namespace LearningSpecFlowProject.Pages
{
    public class InstallationPage : GeneralPage
    {
        private static InstallationPage? installationPage;
        public static new InstallationPage? Instance => installationPage ?? new InstallationPage();
    }
}