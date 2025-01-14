using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using EpamCom.TestFramework.Core.Browser;
using EpamCom.TestFramework.Core.Utilities;
using NUnit.Framework.Interfaces;
using EpamCom.TestFramework.Core.Extensions;
using OpenQA.Selenium.Support.Extensions;
using EpamCom.TestFramework.Core.Configuration;

namespace EpamCom.TestFramework.Tests;

public class BaseTest
{
    protected IWebDriver? Driver { get; private set; }

    protected DefaultWait<IWebDriver>? Wait { get; private set; }

    private readonly string screenshotsDirPath = FilePathes.ScreenShotsPath;

    private string ScreenshotFileName => $"{TestContext.CurrentContext.Test.MethodName}_{Driver?.GetType().Name}_{FilePathHelper.CurrentTimeStamp}";

    [SetUp]
    public void BeforeTest()
    {
        Driver = DriverManager.Driver;
        Wait = DriverManager.Wait;
    }

    [TearDown]
    public void AfterTest()
    {
        if(TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
        {
            Driver.TakeScreenshot(ScreenshotFileName, screenshotsDirPath);
        }

        DriverManager.QuitDriver();
    }



}