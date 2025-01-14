using EpamCom.TestFramework.Core.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace EpamCom.TestFramework.Business.Pages;

public class SearchForm(IWebElement form, IWebDriver driver, DefaultWait<IWebDriver> wait)
: BaseComponent(form, driver, wait)
{
    private readonly Logger<SearchForm> logger = new();

    private IWebElement SearchField => Element.FindElement(By.TagName("input"));

    private IWebElement SearchBtn => Element.FindElement(By.TagName("button"));

    public SearchForm InputSearchText(string text)
    {
        logger.Debug($"Typing {text} in Search field");
        this.Wait.Until(d => SearchField.Displayed);
        SearchField.SendKeys(text);
        return this;
    }

    public SearchResultsPage Search()
    {
        logger.Debug("Clicking on Search button and going to Search results page");
        SearchBtn.Click();
        return new SearchResultsPage(Driver, Wait);
    }
}
