using EpamCom.TestFramework.Core.Configuration;
using EpamCom.TestFramework.Core.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace EpamCom.TestFramework.Business.Pages;

public class SearchedPage : BasePage
{
    private readonly Logger<SearchedPage> logger = new();

    private readonly string url;

    public SearchedPage(string url, IWebDriver driver, DefaultWait<IWebDriver> wait)
    : base(driver, wait)
    {
        this.url = ConfigurationManager.TestConfiguration.Url + url;
    }

    private IWebElement Text => Driver.FindElement(By.TagName("main"));

    public SearchedPage OpenPage()
    {
        logger.Debug("Opening searched page");
        Driver.Url = this.url;
        return this;
    }

    public string GetText()
    {
        Wait.Until(d => Text.Displayed);
        var text = Text.Text;
        logger.Info($"Searched page text:\n{text}\n");
        return text;
    }
}
