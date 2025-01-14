using EpamCom.TestFramework.Business.Pages;
using EpamCom.TestFramework.Core.Utilities;

namespace EpamCom.TestFramework.Tests;

public class GlobalSearchTests : BaseTest
{
    private readonly Logger<GlobalSearchTests> logger = new();

    [Test]
    [TestCase("BLOCKCHAIN", ExpectedResult = true)]
    public bool GlobalSearchFromMainPage(string keyword)
    {
        logger.Info($"Start {TestContext.CurrentContext.Test.MethodName} test with parameters {keyword}");

        var searchedPages = new MainPage(this.Driver!, this.Wait!).
        OpenPage().
        AcceptCookie().
        OpenSearch().
        InputSearchText(keyword).
        Search().
        GetSearchedPages();

        logger.Info($"Searched pages number: {searchedPages.Count} pages");

        return searchedPages.Count != 0 && searchedPages.All(page =>
            page.
            OpenPage().
            GetText().
            Contains(keyword, StringComparison.InvariantCultureIgnoreCase));
    }
}
