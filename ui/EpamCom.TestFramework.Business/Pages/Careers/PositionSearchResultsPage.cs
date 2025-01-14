using System.Collections.ObjectModel;
using EpamCom.TestFramework.Core.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace EpamCom.TestFramework.Business.Pages;

public class PositionSearchResultsPage(IWebDriver driver, DefaultWait<IWebDriver> wait)
: BasePage(driver, wait)
{
    private readonly Logger<PositionSearchResultsPage> logger = new();

    private ReadOnlyCollection<IWebElement> SearchResultListItems => Driver.FindElements(By.CssSelector("li.search-result__item"));

    public PositionSearchResultsElement? FindLatestInResult()
    {
        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        var results = SearchResultListItems;
        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);

        logger.Info($"Founded Positions number: {results.Count} ");
        logger.Debug("Searching latest result from Positions Search Results");

        return results.Count > 0 ?
        new PositionSearchResultsElement(SearchResultListItems[^1], Driver, Wait) :
        null;
    }
}