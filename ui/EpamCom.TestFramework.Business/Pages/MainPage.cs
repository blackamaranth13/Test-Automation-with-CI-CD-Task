using EpamCom.TestFramework.Core.Configuration;
using EpamCom.TestFramework.Core.Extensions;
using EpamCom.TestFramework.Core.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace EpamCom.TestFramework.Business.Pages;

public class MainPage(IWebDriver driver, DefaultWait<IWebDriver> wait)
: BasePage(driver, wait)
{
    private readonly Logger<MainPage> logger = new();
    private readonly string Url =  ConfigurationManager.TestConfiguration.Url;
    private IWebElement AcceptAllCookieBtn => Driver.FindElement(By.CssSelector("button#onetrust-accept-btn-handler"));

    private IWebElement CareersLink => Driver.FindElement(By.LinkText("Careers"));

    private IWebElement AboutLink => Driver.FindElement(By.LinkText("About"));

    private IWebElement InsightsLink => Driver.FindElement(By.LinkText("Insights"));

    private IWebElement MagnifierBtn => Driver.FindElement(By.ClassName("header-search__button"));

    private IWebElement SearchForm => Driver.FindElement(By.CssSelector("form[action = '/search']"));

    public MainPage OpenPage()
    {
        logger.Debug("Openining Main page");
        Driver.Url = Url;
        return this;
    }

    public MainPage AcceptCookie()
    {
        logger.Debug("Accepeting cookie");
        Wait.Until(d => AcceptAllCookieBtn.Displayed);
        Wait.UntilAction(() => AcceptAllCookieBtn.Click());
        return this;
    }

    public CareersPage GoToCareers()
    {
        logger.Debug("Going to Careers page");
        Wait.Until(d => CareersLink).Click();
        return new CareersPage(Driver, Wait);
    }

    public SearchForm OpenSearch()
    {
        logger.Debug("Opening Search");
        MagnifierBtn.Click();
        Wait.Until(d => SearchForm.Displayed);
        return new SearchForm(SearchForm, Driver, Wait);
    }

    public AboutPage GoToAbout()
    {
        logger.Debug("Going to About Page");
        Wait.Until(d => AboutLink).Click();
        return new AboutPage(Driver, Wait);
    }

    public InsightsPage GoToInsights()
    {
        logger.Debug("Going to Insights Page");
        Wait.Until(d => InsightsLink).Click();
        return new InsightsPage(Driver, Wait);
    }
}
