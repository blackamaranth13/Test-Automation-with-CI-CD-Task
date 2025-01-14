using JSONPlaceholder.TestFramework.Core.Utilities;
using Microsoft.Extensions.Configuration;

namespace JSONPlaceholder.TestFramework.Core.Configuration;

public class ConfigurationManager
{
    public static TestConfiguration TestConfiguration { get; }

    public static IConfiguration Config {get;}

    static ConfigurationManager()
    {
        Config = new ConfigurationBuilder().
            SetBasePath(FilePathHelper.ProjectDir).
            AddJsonFile("appsettings.json", optional: false, reloadOnChange : true).
            Build();

        TestConfiguration = Config.Get<TestConfiguration>() ?? new TestConfiguration();

    }

}
