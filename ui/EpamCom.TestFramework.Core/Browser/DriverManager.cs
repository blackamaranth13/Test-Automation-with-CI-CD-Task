using EpamCom.TestFramework.Core.Configuration;
using EpamCom.TestFramework.Core.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace EpamCom.TestFramework.Core.Browser;

public class DriverManager
{
    private static Logger<DriverManager> logger = new();
    private static string browser = ConfigurationManager.TestConfiguration.Browser;
    private static int timeOut = ConfigurationManager.TestConfiguration.TimeOut;

    private static IWebDriver? driver;
    private static DefaultWait<IWebDriver>? wait;

    public static IWebDriver Driver
    {
        get
        {
            driver ??= ConfigNewDriver(browser);
            return driver;
        }
    }

    public static DefaultWait<IWebDriver> Wait
    {
        get
        {
            wait ??= ConfigNewWait(Driver);
            return wait;
        }
    }

    public static void QuitDriver()
    {
        logger.Debug("Quitting browser");
        driver?.Quit();
        driver = null;
        wait = null;
    }

    private static IWebDriver ConfigNewDriver(string browserName)
    {
        logger.Debug($"Configuring browser {browserName}");
        IWebDriver result = Enum.Parse(typeof(BrowserType), browserName) switch
        {
            BrowserType.Chrome => new ChromeDriver(BrowserOptions.GetChromeOptions()),
            BrowserType.Edge => new EdgeDriver(BrowserOptions.GetEdgeOptions()),
            BrowserType.Firefox => new FirefoxDriver(BrowserOptions.GetFirefoxOptions()),
            _ => throw new ArgumentException("Unknown type of browser"),
        };

        result.Manage().Window.Maximize();

        return result;
    }

    private static DefaultWait<IWebDriver> ConfigNewWait(IWebDriver waitedDriver)
    {
        var result = new DefaultWait<IWebDriver>(waitedDriver)
        {
            Timeout = TimeSpan.FromSeconds(timeOut),
            PollingInterval = TimeSpan.FromMilliseconds(50),
        };

        result.IgnoreExceptionTypes(
            typeof(NoSuchElementException),
            typeof(NotFoundException),
            typeof(ElementNotInteractableException),
            typeof(ElementClickInterceptedException));

        return result;
    }
}