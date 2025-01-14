using EpamCom.TestFramework.Core.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace EpamCom.TestFramework.Business.Pages;

public class PositionSearchResultsElement(IWebElement element, IWebDriver driver, DefaultWait<IWebDriver> wait)
: BaseComponent(element, driver, wait)
{
    private readonly Logger<PositionSearchResultsElement> logger = new();

    private IWebElement ViewBtn => Element.FindElement(By.XPath("//a[contains(text(), 'View')]"));

    public PositionPage ViewPosition()
    {
        logger.Debug("Clicking on View position button");

        Wait.Until(d => ViewBtn).Click();
        return new PositionPage(Driver, Wait);
    }
}
