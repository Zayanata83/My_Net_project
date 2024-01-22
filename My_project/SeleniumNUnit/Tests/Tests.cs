using OpenQA.Selenium;
using SeleniumNUnit.Business.WebPages.Pages;
using SeleniumNUnit.Business.WebPages.PageSections;
using LumenWorks.Framework.IO.Csv;
using SeleniumNUnit.Core.Utilities;
using SeleniumNUnit.Core.Extentions;
using SeleniumNUnit.Business.BusinessEnums;
using SeleniumNUnit.Tests.Utils;
using SeleniumNUnit.Core.Driver;
using NUnit.Framework.Interfaces;
using SeleniumNUnit.Core.BrowserUtils;
using NUnit.Framework;

namespace SeleniumNUnit.Tests
{
    [TestFixture]
    public class Tests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = DriverManagerFactory.GetManager(DriverType.Chrome).GetDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            AppUtilities.OpenApplication(driver);
        }

        [TestCase("All Locations")]
        [Test]
        public void ValidateUserCanSearchPositionByCriteriaTest(string location)
        {
            HeaderSection headerSection = new HeaderSection(driver);
            headerSection.ClickHamburgerMenu();
            CareersPage? careersPage = headerSection.ClickExpandedHamburgerMenuItem(HeaderHamburgerMenu.Careers) as CareersPage;
            careersPage.jobSearchFilterForm.EnterSearchKeyword("C#");
            careersPage.jobSearchFilterForm.ClickLocation();
            careersPage.jobSearchFilterForm.SelectLocationFromList(location);
            careersPage.jobSearchFilterForm.ClickRemoteJobCheckbox();
            JoinOurTeamPage joinOurTeamPage = careersPage.jobSearchFilterForm.ClickFindButton();
            string firstJobTitleOnRelevance = joinOurTeamPage.GetFirstProposedJobTitle();
            joinOurTeamPage.ClickDateFilter();
            joinOurTeamPage.MoveToViewAndApplyButton(firstJobTitleOnRelevance);
            joinOurTeamPage.ClickViewAndApplyButton();
            bool isContainsData = driver.IsPageSourceContainData("C#");
            Assert.IsTrue(isContainsData, "Job description doesn't contain data");
        }


        [Test, TestCaseSource(nameof(GetTestData))]
        public void ValidateGlobalSearchingTest(string data)
        {
            HeaderSection headerSection = new HeaderSection(driver);
            headerSection.ClickSearchIcon();
            headerSection.EnterSearchWord(data);
            SearchPage searchPage = headerSection.ClickFindButton();
            bool isContainData = searchPage.AreAllLinksContainText(data);
            Assert.IsTrue(isContainData, "All links don't contain data");
        }

        private static IEnumerable<string[]> GetTestData()
        {
            var csv = new CsvReader(File.OpenText("test-data.csv"));

            while (csv.ReadNextRecord())
            {
                string data = csv[0];
                yield return new[] { data };
            }
        }

        [TestCase("EPAM_Corporate_Overview_Q3_october.pdf")]
        [Test]
        public void ValidateFileDownloadFunctionWorkCorrectlyTest(string fileName)
        {
            HeaderSection headerSection = new HeaderSection(driver);
            headerSection.ClickHamburgerMenu();
            AboutPage? aboutPage = headerSection.ClickExpandedHamburgerMenuItem(HeaderHamburgerMenu.About) as AboutPage;
            aboutPage.ScrollToDownloadButton();
            aboutPage.ClickDownloadButton();
            bool isDownloaded = FileUtilities.IsFileDownloaded(driver, fileName);
            FileUtilities.DeleteDownloadedFile(fileName);
            Assert.IsTrue(isDownloaded, $"File {fileName} isn't downloaded");
        }

        [Test]
        public void ValidateFileOfArticleMatchesTitleCarouselTest()
        {
            HeaderSection headerSection = new HeaderSection(driver);
            headerSection.ClickHamburgerMenu();
            InsightsPage? insightsPage = headerSection.ClickExpandedHamburgerMenuItem(HeaderHamburgerMenu.Insights) as InsightsPage;
            insightsPage.SwipeCarousel();
            insightsPage.SwipeCarousel();
            string nameOfArticleOnSlide = insightsPage.GetArticleName();
            BlogsPage blogsPage = insightsPage.ClickReadMoreLink();
            string articleNameOnBlogsPage = blogsPage.GetArticleName();
            Assert.That(nameOfArticleOnSlide, Is.EqualTo(articleNameOnBlogsPage), "Article name on the carousel doesn't equal to article name on the Blogs page");
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                ScreenshotMaker.TakeFullDisplayScreenshot();
            }
            AppUtilities.CloseBrowser(driver);
        }
    }
}