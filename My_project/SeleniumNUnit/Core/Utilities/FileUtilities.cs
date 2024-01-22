using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumNUnit.Core.Utilities
{
    public static class FileUtilities
    {
        public static bool IsFileDownloaded(IWebDriver driver, string fileName)
        {
            try
            {
                LogManager.GetCurrentClassLogger().Trace("Attempting to check if file is downloaded");
                string Path = Environment.GetEnvironmentVariable("USERPROFILE") + "\\Downloads";
                var filePaths = Directory.GetFiles(Path).ToList();
                new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(d => filePaths.Any(p=>p.Contains(fileName)));
                return filePaths.Any(p => p.Contains(fileName));
            }
            catch (UnauthorizedAccessException ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex, "Unable to authorize access");
                return false;
            }
        }

        public static void DeleteDownloadedFile(string fileName)
        {
            LogManager.GetCurrentClassLogger().Trace("Attempting to delete Downloaded file");
            string Path = Environment.GetEnvironmentVariable("USERPROFILE") + "\\Downloads";
            var filePaths = Directory.GetFiles(Path).ToList();
            try
            {
                foreach (var p in filePaths.Where(p => p.Contains(fileName)))
                {
                    File.Delete(p);
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex, "Unable to authorize access");
            }
            LogManager.GetCurrentClassLogger().Info("Deleted downloaded file");
        }
    }
}