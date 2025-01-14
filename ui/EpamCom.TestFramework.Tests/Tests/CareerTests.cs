using EpamCom.TestFramework.Business.Pages;
using EpamCom.TestFramework.Core.Utilities;

namespace EpamCom.TestFramework.Tests;

public class CareerTests : BaseTest
{
    private readonly Logger<CareerTests> logger = new();

    [Test]
    [TestCase("Python", "All Locations", ExpectedResult = true)]
    public bool SearchPositionByKeywordRemoteSelected(string keyword, string location)
    {
        logger.Info($"Starting {TestContext.CurrentContext.Test.MethodName} test with parameters {keyword} {location}");

        var positionText = new MainPage(this.Driver!, this.Wait!).
        OpenPage().
        AcceptCookie().
        GoToCareers().
        SelectRemote().
        InputKeyWord(keyword).
        SelectLocation(location).
        FindPosition().
        FindLatestInResult()?.
        ViewPosition().
        GetPositionText();

        return positionText?.Contains(keyword, StringComparison.InvariantCultureIgnoreCase) ?? false;
    }

}
