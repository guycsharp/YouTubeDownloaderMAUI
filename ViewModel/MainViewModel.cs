using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CliWrap;
using CliWrap.EventStream;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using YouTubeDownloaderMAUI.Services;
using Microsoft.Maui.Controls;

namespace YouTubeDownloaderMAUI.ViewModel;

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

    [ObservableProperty]
    private string _errorMessage = string.Empty;

    [ObservableProperty]
    private bool _hasError;

    [RelayCommand]
    private async Task Download()
    {
        if (string.IsNullOrWhiteSpace(PlaylistUrl))
        {
            HasError = true;
            ErrorMessage = "Please enter a playlist URL.";
            AddLog("Missing playlist URL.");
            return;
        }

        try
        {
            HasError = false;
            ErrorMessage = string.Empty;
            IsBusy = true;
            StatusMessage = "Preparing...";
            Progress = 0;

            await ExecutableService.EnsureExecutablesExist();

            // ✅ Use tools shipped in Tools/ folder
            var toolsPath = Path.Combine(AppContext.BaseDirectory, "Tools");
            var ytDlpPath = Path.Combine(toolsPath, "yt-dlp.exe");
            var ffmpegBinPath = Path.Combine(toolsPath, "ffmpeg", "bin");

            var arguments = SelectedFormat == "MP4 (Video)"
                ? "-f \"bestvideo+bestaudio\" --merge-output-format mp4 --embed-thumbnail --embed-metadata -o \"./%(playlist_title)s/%(playlist_index)s - %(title)s.%(ext)s\""
                : "-x --audio-format mp3 --embed-thumbnail -o \"./%(playlist_title)s/%(playlist_index)s - %(title)s.%(ext)s\"";

            arguments += $" \"{PlaylistUrl}\"";

            AddLog($"Running command: yt-dlp {arguments}");

            var cmd = Cli.Wrap(ytDlpPath)
                        .WithArguments(arguments)
                        .WithWorkingDirectory(AppContext.BaseDirectory)
                        .WithEnvironmentVariables(env =>
                            env.Set("PATH", $"{Environment.GetEnvironmentVariable("PATH")};{ffmpegBinPath}"));

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
                        UpdateProgressBarFromOutput(stdOut.Text);
                        break;

                    case StandardErrorCommandEvent stdErr:
                        AddLog($"ERROR: {stdErr.Text}");
                        break;

                    case ExitedCommandEvent exited:
                        AddLog($"Process exited (Code: {exited.ExitCode})");
                        break;
                }
            }

            Progress = 1.0;
            AddLog("Download completed!");
            StatusMessage = "Completed successfully!";
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Download failed: {ex.Message}";
            HasError = true;
            AddLog($"Error: {ex.Message}");
            StatusMessage = "Download failed!";
            Progress = 0;
        }
        finally
        {
            IsBusy = false;
        }
    }

    private void UpdateProgressBarFromOutput(string line)
    {
        var match = Regex.Match(line, @"(?<percent>\d{1,3}(?:\.\d+)?)%");
        if (match.Success && double.TryParse(match.Groups["percent"].Value, out double percent))
        {
            Progress = Math.Clamp(percent / 100.0, 0.0, 1.0);
        }
    }

    [RelayCommand]
    private async Task Paste()
    {
        PlaylistUrl = await Clipboard.Default.GetTextAsync() ?? string.Empty;
        AddLog("Pasted URL from clipboard");
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
