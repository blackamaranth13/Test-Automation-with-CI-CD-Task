using EpamCom.TestFramework.Business.Pages;
using EpamCom.TestFramework.Core.Utilities;

namespace EpamCom.TestFramework.Tests;

public class InsightsTests : BaseTest
{
    private readonly Logger<InsightsTests> logger = new();

    [Test]
    [TestCase(2)]
    public void InsightsArticleSwipe(int swipesNumber)
    {
        logger.Info($"Start {TestContext.CurrentContext.Test.MethodName} test with parameters {swipesNumber}");

        var carousel = new MainPage(this.Driver!, this.Wait!).
        OpenPage().
        AcceptCookie().
        GoToInsights().
        SwipeArticle(swipesNumber);

        var expected = carousel.
        GetArticleTitle().
        Trim();
        var actual = carousel.
        GoReadMore().
        GetArticleTitle().
        Trim();
        Assert.That(actual, Is.EqualTo(expected));
    }
}
