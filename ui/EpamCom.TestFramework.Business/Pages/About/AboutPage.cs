using EpamCom.TestFramework.Core.Extensions;
using EpamCom.TestFramework.Core.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace EpamCom.TestFramework.Business.Pages;

public class AboutPage(IWebDriver driver, DefaultWait<IWebDriver> wait)
: BasePage(driver, wait)
{
    private Logger<AboutPage> logger = new();
    private IWebElement DownLoadBtn => Driver.FindElement(By.CssSelector("a[download = '']"));

    private IWebElement EpamAtGlanceLabel => Driver.FindElement(By.XPath("//span[contains(text(), 'EPAM at')]"));

    public AboutPage ScrollToEpamAtGlance()
    {
        logger.Debug("Scrolling to Epam At Glance");
        Wait.UntilAction(() => Driver.ScrollToElement(EpamAtGlanceLabel));
        return this;
    }

    public void DownLoadCompanyOverview()
    {
        logger.Debug("Downloading company overview file");
        Wait.UntilAction(() => DownLoadBtn.Click());
    }

}
