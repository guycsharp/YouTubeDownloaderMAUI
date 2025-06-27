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
using Microsoft.Maui.Storage;

namespace YouTubeDownloaderMAUI.ViewModel;

// This ViewModel handles all app logic and user interaction bindings
public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private string _playlistUrl = string.Empty;

    [ObservableProperty]
    private bool _isBusy;

    [ObservableProperty]
    private double _progress;

    [ObservableProperty]
    private string _progressText = string.Empty;

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

    // This is where the user wants to save the downloaded files
    [ObservableProperty]
    private string _destinationFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

    // 🗂 Simulated folder picker using FilePicker (most compatible fallback)
    [RelayCommand]
    private async Task Browse()
    {
        try
        {
            var result = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Pick any file inside your target folder"
            });

            if (result != null)
            {
                DestinationFolder = Path.GetDirectoryName(result.FullPath);
                AddLog($"Selected destination: {DestinationFolder}");
            }
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Failed to pick folder: {ex.Message}";
            HasError = true;
        }
    }

    // 🧭 User taps Download — validate, construct command, stream progress
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

        if (string.IsNullOrWhiteSpace(DestinationFolder) || !Directory.Exists(DestinationFolder))
        {
            HasError = true;
            ErrorMessage = "Invalid destination folder.";
            AddLog("Invalid destination folder.");
            return;
        }

        try
        {
            HasError = false;
            ErrorMessage = string.Empty;
            IsBusy = true;
            StatusMessage = "Preparing...";
            Progress = 0;
            ProgressText = string.Empty;

            await ExecutableService.EnsureExecutablesExist();

            var toolsPath = Path.Combine(AppContext.BaseDirectory, "Tools");
            var ytDlpPath = Path.Combine(toolsPath, "yt-dlp.exe");
            var ffmpegBinPath = Path.Combine(toolsPath, "ffmpeg", "bin");

            var outputPath = Path.Combine(DestinationFolder, "%(playlist_title)s", "%(playlist_index)s - %(title)s.%(ext)s");

            var arguments = SelectedFormat == "MP4 (Video)"
                ? $"-f \"bestvideo+bestaudio\" --merge-output-format mp4 --embed-thumbnail --embed-metadata -o \"{outputPath}\""
                : $"-x --audio-format mp3 --embed-thumbnail -o \"{outputPath}\"";

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
            ProgressText = "100%";
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
            ProgressText = string.Empty;
        }
        finally
        {
            IsBusy = false;
        }
    }

    // 🔁 Extract percent progress from yt-dlp output and update UI
    private void UpdateProgressBarFromOutput(string line)
    {
        var match = Regex.Match(line, @"(?<percent>\d{1,3}(?:\.\d+)?)%");
        if (match.Success && double.TryParse(match.Groups["percent"].Value, out double percent))
        {
            double clamped = Math.Clamp(percent / 100.0, 0.0, 1.0);
            Progress = clamped;
            ProgressText = $"{percent:F1}%";
        }
    }

    // 📋 Clipboard paste helper
    [RelayCommand]
    private async Task Paste()
    {
        PlaylistUrl = await Clipboard.Default.GetTextAsync() ?? string.Empty;
        AddLog("Pasted URL from clipboard");
    }

    // 📎 Allow tapping red error message to copy it
    [RelayCommand]
    private async Task CopyError()
    {
        if (!string.IsNullOrWhiteSpace(ErrorMessage))
        {
            await Clipboard.Default.SetTextAsync(ErrorMessage);
            AddLog("Error message copied to clipboard.");
        }
    }

    // 🧾 Add text to visible log list with a timestamp
    private void AddLog(string message)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            LogEntries.Add($"[{DateTime.Now:HH:mm:ss}] {message}");
            OnPropertyChanged(nameof(LogEntries));
        });
    }
}
