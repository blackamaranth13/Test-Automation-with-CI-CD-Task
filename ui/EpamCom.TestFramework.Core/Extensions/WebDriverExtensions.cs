using EpamCom.TestFramework.Core.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;

namespace EpamCom.TestFramework.Core.Extensions;

public static class WebDriverExtensions
{
    private static Logger<WebDriver> logger = new();

    public static void ScrollToElement(this IWebDriver driver, IWebElement element)
    {
        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
        js.ExecuteScript("arguments[0].scrollIntoView();", element);
    }

    public static void SwipeToLeft(this IWebDriver driver, IWebElement element)
    {
        new Actions(driver).
        MoveToElement(element).
        ClickAndHold().
        MoveToLocation(0, 0).
        MoveToLocation(0, 0). // it works only when called twice
        Click().
        Release().
        Pause(TimeSpan.FromSeconds(1)).
        Build().
        Perform();
    }

    public static void TakeScreenshot(this IWebDriver driver, string fileName, string path)
    {
        Directory.CreateDirectory(path);

        var fullScreenshotPath = Path.Combine(path, fileName + ".png");

        logger.Debug($"Taking screenshot and saving it to {fullScreenshotPath}");
        driver?.TakeScreenshot().SaveAsFile(fullScreenshotPath);

    }
}
