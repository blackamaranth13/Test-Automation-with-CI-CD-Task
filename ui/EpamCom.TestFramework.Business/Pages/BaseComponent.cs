using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace EpamCom.TestFramework.Business.Pages;

public class BaseComponent : BasePage
{
    protected IWebElement Element { get; }

    protected BaseComponent(IWebElement element, IWebDriver driver, DefaultWait<IWebDriver> wait)
    : base(driver, wait)
    {
        this.Element = element;
    }
}
