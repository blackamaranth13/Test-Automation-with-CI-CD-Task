using EpamCom.TestFramework.Core.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace EpamCom.TestFramework.Core.Utilities;

public class DownloadFolder
{
    private readonly Logger<DownloadFolder> logger = new();
    private string directoryPath;
    private DirectoryInfo directory;

    public DownloadFolder(string downloadFolderPath)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(downloadFolderPath);

        directoryPath = downloadFolderPath;
        directory = new DirectoryInfo(downloadFolderPath);
    }

    public void PrepareForDownload()
    {
        directory.Create();
        directory.DeleteAllFiles();
    }

    public bool WaitForFileDownLoad(string fileName)
    {
        var wait = CreateFileWait(fileName);

        logger.Debug($"Waiting for download file {fileName} in {directoryPath}");

        var result = false;
        try
        {
            result = wait.Until(f => directory.GetFiles().Length > 0 && f.Exists);
        }
        catch (WebDriverTimeoutException e)
        {
            logger.Error($"{e.Message}");
        }

        return result;
    }

    private DefaultWait<FileInfo> CreateFileWait(string fileName)
    {
        return new DefaultWait<FileInfo>(new FileInfo(Path.Combine(directoryPath, fileName)))
        {
            Timeout = TimeSpan.FromSeconds(10),
            PollingInterval = TimeSpan.FromSeconds(2),
            Message = "File is not downloaded"
        };
    }



}
