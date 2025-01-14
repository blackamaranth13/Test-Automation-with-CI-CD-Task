namespace JSONPlaceholder.TestFramework.Core.Utilities;

public static class FilePathHelper
{
    public static string ProjectDir => Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.FullName!;

    public static string CurrentTimeStamp => DateTime.Now.ToString("HH-mm-ss_dd-MM-yy");
}
