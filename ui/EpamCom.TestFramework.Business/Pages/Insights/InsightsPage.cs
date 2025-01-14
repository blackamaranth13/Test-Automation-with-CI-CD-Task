using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using EpamCom.TestFramework.Core.Extensions;
using EpamCom.TestFramework.Core.Utilities;

namespace EpamCom.TestFramework.Business.Pages;

public class InsightsPage(IWebDriver driver, DefaultWait<IWebDriver> wait)
: BasePage(driver, wait)
{
    private readonly Logger<InsightsPage> logger = new();

    private IWebElement ActiveCarousel => Driver.FindElement(By.XPath("(//div[@class = 'owl-item active'])[1]"));


    public CarouselComponent SwipeArticle(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Wait.Until(d => ActiveCarousel.Displayed);
            Wait.UntilAction(() => Driver.SwipeToLeft(ActiveCarousel));
            logger.Debug("Swiping article");
        }

        Wait.Until(d => ActiveCarousel.Displayed);
        return new CarouselComponent(ActiveCarousel, Driver, Wait);
    }
}
