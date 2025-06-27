using System.Diagnostics;
using System.Net;

namespace YouTubeDownloaderMAUI.Services;

public class ExecutableService
{
    public static async Task EnsureExecutablesExist()
    {
        var binPath = Path.Combine(AppContext.BaseDirectory, "bin");
        Directory.CreateDirectory(binPath);

        await DownloadFileAsync(
            "https://github.com/yt-dlp/yt-dlp/releases/latest/download/yt-dlp.exe",
            Path.Combine(binPath, "yt-dlp.exe")
        );

        await DownloadFileAsync(
            "https://github.com/GyanD/codexffmpeg/releases/download/6.0/ffmpeg-6.0-full_build.zip",
            Path.Combine(binPath, "ffmpeg.zip")
        );

        // Extract ffmpeg
        var extractPath = Path.Combine(binPath, "ffmpeg");
        if (!Directory.Exists(extractPath))
        {
            Directory.CreateDirectory(extractPath);
            Process.Start("tar", $"xf \"{Path.Combine(binPath, "ffmpeg.zip")}\" -C \"{extractPath}\"").WaitForExit();
        }
    }

    private static async Task DownloadFileAsync(string url, string outputPath)
    {
        if (File.Exists(outputPath)) return;

        using var httpClient = new HttpClient();
        using var response = await httpClient.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
        using var stream = await response.Content.ReadAsStreamAsync();
        using var fileStream = new FileStream(outputPath, FileMode.Create);
        await stream.CopyToAsync(fileStream);
    }
}