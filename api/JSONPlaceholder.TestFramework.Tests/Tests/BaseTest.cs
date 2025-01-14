using JSONPlaceholder.TestFramework.Business.Client;
using JSONPlaceholder.TestFramework.Core.Configuration;

namespace JSONPlaceholder.TestFramework.Tests;

public class BaseTest
{
    protected JsonPlaceholderClient Client { get; private set;}

    [SetUp]
    public void BeforeTest()
    {
        Client = new JsonPlaceholderClient(ConfigurationManager.TestConfiguration.Url);
    }
}