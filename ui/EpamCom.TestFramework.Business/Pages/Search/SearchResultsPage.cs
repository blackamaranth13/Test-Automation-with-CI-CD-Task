using System.Collections.ObjectModel;
using EpamCom.TestFramework.Core.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace EpamCom.TestFramework.Business.Pages;

public class SearchResultsPage(IWebDriver driver, DefaultWait<IWebDriver> wait)
: BasePage(driver, wait)
{
    private readonly Logger<SearchResultsPage> logger = new();

    private ReadOnlyCollection<IWebElement> SearchResultsLinks => Driver.FindElements(By.CssSelector("a.search-results__title-link"));

    public ICollection<SearchedPage> GetSearchedPages()
    {
        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        var results = SearchResultsLinks;
        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
        
        logger.Info($"Searched {results.Count} pages");
        return results.
        Select(e => e.GetDomAttribute("href")).
        Select(l => new SearchedPage(l, Driver, Wait)).
        ToList();
    }
}
