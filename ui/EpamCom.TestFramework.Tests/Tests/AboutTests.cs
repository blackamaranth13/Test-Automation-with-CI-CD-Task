using EpamCom.TestFramework.Business.Pages;
using EpamCom.TestFramework.Core.Utilities;
using EpamCom.TestFramework.Core.Configuration;

namespace EpamCom.TestFramework.Tests;

public class AboutTests : BaseTest
{
    private readonly Logger<AboutTests> logger = new();

    [Test]
    [TestCase("EPAM_Corporate_Overview_Q4_EOY.pdf", ExpectedResult = true)]
    public bool CompanyOverviewDownLoad(string fileName)
    {
        logger.Info($"Start {TestContext.CurrentContext.Test.MethodName} test with parameters {fileName}");

        var downloadFolder = new DownloadFolder(FilePathes.DownloadPath);
        downloadFolder.PrepareForDownload();

        new MainPage(this.Driver!, this.Wait!).
        OpenPage().
        AcceptCookie().
        GoToAbout().
        ScrollToEpamAtGlance().
        DownLoadCompanyOverview();

        return downloadFolder.WaitForFileDownLoad(fileName);
    }

}
