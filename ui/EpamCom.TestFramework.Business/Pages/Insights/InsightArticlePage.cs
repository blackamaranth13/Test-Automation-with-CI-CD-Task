using EpamCom.TestFramework.Core.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace EpamCom.TestFramework.Business.Pages;

public class InsightArticlePage(IWebDriver driver, DefaultWait<IWebDriver> wait)
: BasePage(driver, wait)
{
    private readonly Logger< InsightArticlePage> logger = new();

    private IWebElement ArticleTitle => Driver.FindElement(By.CssSelector("span.font-size-80-33 :first-of-type"));

    public string GetArticleTitle()
    {
        Wait.Until(d => ArticleTitle.Enabled);
        var text = ArticleTitle.Text;
        logger.Info($"Article title: {text}");
        return text;
    }

}
