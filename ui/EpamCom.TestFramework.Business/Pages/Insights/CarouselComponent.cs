using EpamCom.TestFramework.Core.Extensions;
using EpamCom.TestFramework.Core.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace EpamCom.TestFramework.Business.Pages;

public class CarouselComponent(IWebElement carousel, IWebDriver driver, DefaultWait<IWebDriver> wait)
: BaseComponent(carousel, driver, wait)
{
    private readonly Logger<CarouselComponent> logger = new();
    private IWebElement ArticleTitle => Element.FindElement(By.CssSelector("span.font-size-60"));

    private IWebElement ReadMoreLink => Element.FindElement(By.PartialLinkText("Read More"));

    public string GetArticleTitle()
    {
        var text = ArticleTitle.Text;
        logger.Info($"Carousel article title: {text}");
        return text;
    }

    public InsightArticlePage GoReadMore()
    {
        logger.Debug("Clicking Read more and going to article page");
        Wait.UntilAction(() => ReadMoreLink.Click());

        return new InsightArticlePage(Driver, Wait);
    }
}
