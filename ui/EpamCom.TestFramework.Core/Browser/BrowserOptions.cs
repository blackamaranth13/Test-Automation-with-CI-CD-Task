using EpamCom.TestFramework.Core.Configuration;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace EpamCom.TestFramework.Core.Browser;

public static class BrowserOptions
{
    private static string downloadPath = FilePathes.DownloadPath;

    public static ChromeOptions GetChromeOptions()
    {
        var options = new ChromeOptions();
        if (ConfigurationManager.TestConfiguration.Headless)
        {
            options.AddArgument("--headless");
        }
        options.AddUserProfilePreference("download.default_directory", downloadPath);
        return options;
    }

    public static EdgeOptions GetEdgeOptions()
    {
        var options = new EdgeOptions();
        if (ConfigurationManager.TestConfiguration.Headless)
        {
            options.AddArgument("--headless");
        }
        options.AddUserProfilePreference("download.default_directory", downloadPath);
        return options;
    }

    public static FirefoxOptions GetFirefoxOptions()
    {
        var options = new FirefoxOptions();
        if (ConfigurationManager.TestConfiguration.Headless)
        {
            options.AddArgument("-headless");
        }

        var profile = new FirefoxProfile();
        profile.SetPreference("browser.download.folderList", 2);
        profile.SetPreference("browser.download.dir", downloadPath);
        options.Profile = profile;

        return options;
    }
}
