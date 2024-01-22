using NLog;
using NUnit.Framework;
using System.Configuration;

namespace SeleniumNUnit.Configurations.AppConfigurations
{
    public static class AppConfiguration
    {
        private static Configuration? configuration;

        public static Configuration GetConfiguration()
        {
            if (configuration == null)
            {
                try
                {
                    CreateConfiguration();
                }
                catch (Exception ex)
                {
                    LogManager.GetCurrentClassLogger().Error(ex, "Unable to create Configuration");
                }

            }
            return configuration;
        }

        private static void CreateConfiguration()
        {
            var assemblyDirectory = TestContext.CurrentContext.TestDirectory;
            var path = Path.Combine(assemblyDirectory, "App.config");
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            fileMap.ExeConfigFilename = path;
            configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
        }
    }
}
