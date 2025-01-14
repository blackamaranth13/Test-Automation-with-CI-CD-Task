namespace EpamCom.TestFramework.Core.Configuration;

public class TestConfiguration
{

    public int TimeOut { get; set; } = 10;
    public string Browser { get; set; } = "Chrome";
    public bool Headless { get; set; }
    public string Url { get; set; } = "https://www.epam.com/";

}
