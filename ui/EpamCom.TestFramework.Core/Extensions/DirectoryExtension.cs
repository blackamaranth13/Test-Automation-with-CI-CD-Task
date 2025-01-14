namespace EpamCom.TestFramework.Core.Extensions;

public static class DirectoryExtension
{
    public static void DeleteAllFiles(this DirectoryInfo directoryInfo)
    {
        foreach (var file in directoryInfo?.GetFiles())
        {
            file.Delete();
        }
    }

    public static bool IsNotEmpty(this DirectoryInfo directoryInfo)
    {
        return directoryInfo?.GetFiles().Length > 0;
    }
}
