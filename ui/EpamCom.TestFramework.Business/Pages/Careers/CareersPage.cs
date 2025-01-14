using EpamCom.TestFramework.Core.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace EpamCom.TestFramework.Business.Pages;

public class CareersPage(IWebDriver driver, DefaultWait<IWebDriver> wait)
: BasePage(driver, wait)
{
    private readonly Logger<CareersPage> logger = new();

    private IWebElement KeyWordField => Driver.FindElement(By.Id("new_form_job_search-keyword"));

    private IWebElement LocationsDropdown => Driver.FindElement(By.ClassName("recruiting-search__location"));

    private IWebElement AllLocationsItem => LocationsDropdown.FindElement(By.XPath("//li[@title = 'All Locations']"));

    private IWebElement LocationField => LocationsDropdown.FindElement(By.XPath("//span[@role = 'combobox']"));

    private IWebElement RemoteCheckBox => this.Driver.FindElement(By.CssSelector("input[name = 'remote']+label"));

    private IWebElement FindPositionBtn => this.Driver.FindElement(By.CssSelector("form#jobSearchFilterForm>button"));

    public CareersPage InputKeyWord(string keyword)
    {
        logger.Debug($"Typing {keyword} keyword");

        this.Wait.Until(d => KeyWordField.Enabled);
        KeyWordField.Clear();
        KeyWordField.SendKeys(keyword);
        return this;
    }

    public CareersPage SelectLocation(string location)
    {
        logger.Debug($"Selecting {location} location");

        wait.Until(d => LocationsDropdown).Click();

        if (location == "All Locations")
        {
            this.Wait.Until(d => AllLocationsItem.Displayed);
            AllLocationsItem.Click();
        }
        else
        {
            this.Wait.Until(d => LocationField).SendKeys(location + Keys.Enter);
        }

        return this;
    }

    public CareersPage SelectRemote()
    {
        logger.Debug("Selecting Remote");

        Wait.Until(d => RemoteCheckBox.Enabled);
        RemoteCheckBox.Click();
        return this;
    }

    public PositionSearchResultsPage FindPosition()
    {
        logger.Debug("Clicking on Find and going to Position Search results page");

        Wait.Until(d => FindPositionBtn).Click();
        return new PositionSearchResultsPage(this.Driver, this.Wait);
    }
}