namespace SeleniumNUnit.Core.Driver
{
    public class DriverManagerFactory
    {
        public static DriverManager GetManager(DriverType type)
        {
            DriverManager driverManager;

            switch (type)
            {
                case DriverType.Chrome:
                    driverManager = new ChromeDriverManager();
                    break;
                case DriverType.Firefox:
                    driverManager = new FirefoxDriverManager();
                    break;
                default:
                    driverManager = new SafariDriverManager();
                    break;
            }
            return driverManager;
        }
    }
}