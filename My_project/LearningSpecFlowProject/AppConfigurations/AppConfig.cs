using NUnit.Framework;
using System.Configuration;

namespace LearningSpecFlowProject.AppConfigurations
{
    public static class AppConfig
    {
        private static Configuration? configuration;

        public static Configuration GetConfiguration()
        {
            if (configuration == null)
            {
                CreateConfiguration();
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