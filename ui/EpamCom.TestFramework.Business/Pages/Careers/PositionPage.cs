using EpamCom.TestFramework.Core.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace EpamCom.TestFramework.Business.Pages;

public class PositionPage(IWebDriver driver, DefaultWait<IWebDriver> wait)
: BasePage(driver, wait)
{
    private readonly Logger<PositionPage> logger = new();

    private IWebElement PositionArticle => Driver.FindElement(By.TagName("article"));

    public string GetPositionText()
    {
        Wait.Until(d => PositionArticle.Displayed);
        var text = PositionArticle.Text;

        logger.Info($"Position text:\n{text}\n");

        return text;
    }
}
