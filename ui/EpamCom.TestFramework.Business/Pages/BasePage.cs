using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace EpamCom.TestFramework.Business.Pages;

public class BasePage
{
    protected IWebDriver Driver { get; }

    protected DefaultWait<IWebDriver> Wait { get; }

    protected BasePage(IWebDriver driver, DefaultWait<IWebDriver> wait)
    {
        this.Driver = driver;
        this.Wait = wait;
    }
}
