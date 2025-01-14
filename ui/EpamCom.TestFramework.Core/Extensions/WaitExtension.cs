using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace EpamCom.TestFramework.Core.Extensions;

public static class WaitExtension
{
    public static void UntilAction(this IWait<IWebDriver> wait, Action action)
    {
        wait?.Until(d =>
        {
            action();
            return true;
        });
    }

}
