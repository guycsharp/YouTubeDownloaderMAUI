using CliWrap;
using CliWrap.EventStream;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using YouTubeDownloaderMAUI.Services;

namespace YouTubeDownloaderMAUI.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private string _playlistUrl = string.Empty;

    [ObservableProperty]
    private bool _isBusy;

    [ObservableProperty]
    private double _progress;

    [ObservableProperty]
    private string _statusMessage = "Ready";

    [ObservableProperty]
    private List<string> _logEntries = new();

    [ObservableProperty]
    private List<string> _formats = new() { "MP4 (Video)", "MP3 (Audio)" };

    [ObservableProperty]
    private string _selectedFormat = "MP4 (Video)";

    [RelayCommand]
    private async Task Download()
    {
        if (string.IsNullOrWhiteSpace(PlaylistUrl))
        {
            AddLog("Please enter a playlist URL");
            return;
        }

        try
        {
            IsBusy = true;
            StatusMessage = "Preparing...";
            await ExecutableService.EnsureExecutablesExist();

            var binPath = Path.Combine(AppContext.BaseDirectory, "bin", "ffmpeg", "bin");
            var ytDlpPath = Path.Combine(AppContext.BaseDirectory, "bin", "yt-dlp.exe");

            var arguments = SelectedFormat == "MP4 (Video)" ?
                $"-f \"bestvideo+bestaudio\" --merge-output-format mp4 --embed-thumbnail --embed-metadata -o \"./%(playlist_title)s/%(playlist_index)s - %(title)s.%(ext)s\"" :
                $"-x --audio-format mp3 --embed-thumbnail -o \"./%(playlist_title)s/%(playlist_index)s - %(title)s.%(ext)s\"";

            arguments += $" \"{PlaylistUrl}\"";

            AddLog($"Running command: yt-dlp {arguments}");

            var cmd = Cli.Wrap(ytDlpPath)
                .WithArguments(arguments)
                .WithWorkingDirectory(AppContext.BaseDirectory)
                .WithEnvironmentVariables(env => env
                    .Set("PATH", $"{Environment.GetEnvironmentVariable("PATH")};{binPath}"));

            AddLog("Starting download...");

            await foreach (var cmdEvent in cmd.ListenAsync())
            {
                switch (cmdEvent)
                {
                    case StartedCommandEvent started:
                        AddLog($"Process started (ID: {started.ProcessId})");
                        break;
                    case StandardOutputCommandEvent stdOut:
                        AddLog(stdOut.Text);
                        break;
                    case StandardErrorCommandEvent stdErr:
                        AddLog($"ERROR: {stdErr.Text}");
                        break;
                    case ExitedCommandEvent exited:
                        AddLog($"Process exited (Code: {exited.ExitCode})");
                        break;
                }
            }

            AddLog("Download completed!");
            StatusMessage = "Completed successfully!";
        }
        catch (Exception ex)
        {
            AddLog($"Error: {ex.Message}");
            StatusMessage = "Download failed!";
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private async Task Paste()
    {
        if (Clipboard.Default.HasText)
        {
            PlaylistUrl = await Clipboard.Default.GetTextAsync();
            AddLog("Pasted URL from clipboard");
        }
    }

    private void AddLog(string message)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            LogEntries.Add($"[{DateTime.Now:HH:mm:ss}] {message}");
            OnPropertyChanged(nameof(LogEntries));
        });
    }
}