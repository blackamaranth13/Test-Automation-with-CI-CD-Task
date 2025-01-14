using EpamCom.TestFramework.Core.Utilities;

namespace EpamCom.TestFramework.Core.Configuration;

public class FilePathes
{
    public static string DownloadPath => Path.Combine(FilePathHelper.ProjectDir, "Download");

    public static string ScreenShotsPath => Path.Combine(FilePathHelper.ProjectDir,"FailsScreenshots");


}
