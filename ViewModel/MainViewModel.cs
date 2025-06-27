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

public partial class MainViewModel : ObservableObject
{
    // STEP 0: Set up all the properties bound to the UI

    // (1) The playlist URL entered by the user
    [ObservableProperty]
    private string _playlistUrl = string.Empty;

    // (2) Whether the app is currently busy (downloading)
    [ObservableProperty]
    private bool _isBusy;

    // (3) Progress value (0.0 to 1.0) for the ProgressBar
    [ObservableProperty]
    private double _progress;

    // (4) Text label shown below the ProgressBar (e.g. "43.8%")
    [ObservableProperty]
    private string _progressText = string.Empty;

    // (5) Message shown in the status label ("Preparing...", "Download failed", etc.)
    [ObservableProperty]
    private string _statusMessage = "Ready";

    // (6) Items shown in the scrollable log box
    [ObservableProperty]
    private List<string> _logEntries = new();

    // (7) Format options the user can choose from
    [ObservableProperty]
    private List<string> _formats = new() { "MP4 (Video)", "MP3 (Audio)" };

    // (8) Currently selected format
    [ObservableProperty]
    private string _selectedFormat = "MP4 (Video)";

    // (9) Error message text shown in red below the status
    [ObservableProperty]
    private string _errorMessage = string.Empty;

    // (10) Whether the error label is visible
    [ObservableProperty]
    private bool _hasError;

    // (11) Folder where downloads will be saved
    [ObservableProperty]
    private string _destinationFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

    // ✅ NEW: (12) If true, existing files can be overwritten
    [ObservableProperty]
    private bool _overwriteExisting = false;

    // STEP 1: Let the user pick a file — we’ll extract the containing folder
    [RelayCommand]
    private async Task Browse()
    {
        try
        {
            var file = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Pick any file inside your desired folder"
            });

            if (file != null)
            {
                DestinationFolder = Path.GetDirectoryName(file.FullPath);
                AddLog($"✔ Destination folder set: {DestinationFolder}");
            }
        }
        catch (Exception ex)
        {
            HasError = true;
            ErrorMessage = $"Failed to browse: {ex.Message}";
            AddLog($"❌ Folder selection error: {ex.Message}");
        }
    }

    // STEP 2: Paste clipboard contents into the playlist box
    [RelayCommand]
    private async Task Paste()
    {
        PlaylistUrl = await Clipboard.Default.GetTextAsync() ?? string.Empty;
        AddLog("📋 Pasted from clipboard");
    }

    // STEP 3: Copy current error to clipboard
    [RelayCommand]
    private async Task CopyError()
    {
        if (!string.IsNullOrWhiteSpace(ErrorMessage))
        {
            await Clipboard.Default.SetTextAsync(ErrorMessage);
            AddLog("📎 Error copied to clipboard");
        }
    }

    // STEP 4: Start the download and manage everything top to bottom
    [RelayCommand]
    private async Task Download()
    {
        // STEP 4.1: Input validation
        if (string.IsNullOrWhiteSpace(PlaylistUrl))
        {
            HasError = true;
            ErrorMessage = "Please enter a playlist URL.";
            AddLog("❗ Playlist URL missing.");
            return;
        }

        if (string.IsNullOrWhiteSpace(DestinationFolder) || !Directory.Exists(DestinationFolder))
        {
            HasError = true;
            ErrorMessage = "Please select a valid destination folder.";
            AddLog("❗ Destination folder is invalid.");
            return;
        }

        try
        {
            // STEP 4.2: Reset state before downloading
            HasError = false;
            ErrorMessage = string.Empty;
            IsBusy = true;
            StatusMessage = "Preparing...";
            Progress = 0;
            ProgressText = string.Empty;

            // STEP 4.3: Ensure yt-dlp and ffmpeg are present
            await ExecutableService.EnsureExecutablesExist();

            // STEP 4.4: Build paths to tools
            var toolsPath = Path.Combine(AppContext.BaseDirectory, "Tools");
            var ytDlpPath = Path.Combine(toolsPath, "yt-dlp.exe");
            var ffmpegBinPath = Path.Combine(toolsPath, "ffmpeg", "bin");

            // STEP 4.5: Format file output path
            var outputTemplate = Path.Combine(DestinationFolder, "%(playlist_title)s", "%(playlist_index)s - %(title)s.%(ext)s");

            // STEP 4.6: Compose yt-dlp arguments
            string arguments = SelectedFormat == "MP4 (Video)"
                ? $"-f \"bestvideo+bestaudio\" --merge-output-format mp4 --embed-thumbnail --embed-metadata"
                : $"-x --audio-format mp3 --embed-thumbnail";

            // STEP 4.7: Append output path
            arguments += $" -o \"{outputTemplate}\"";

            // ✅ STEP 4.8: Only skip overwrite protection if user allows
            if (!OverwriteExisting)
            {
                arguments += " --no-overwrites";
            }

            // STEP 4.9: Include the playlist URL
            arguments += $" \"{PlaylistUrl}\"";

            AddLog($"▶ Running yt-dlp with args: {arguments}");

            // STEP 4.10: Set up and execute CLI process
            var cmd = Cli.Wrap(ytDlpPath)
                         .WithArguments(arguments)
                         .WithWorkingDirectory(AppContext.BaseDirectory)
                         .WithEnvironmentVariables(env =>
                             env.Set("PATH", $"{Environment.GetEnvironmentVariable("PATH")};{ffmpegBinPath}"));

            AddLog("🚀 Download started...");

            // STEP 4.11: Stream real-time output from yt-dlp
            await foreach (var cmdEvent in cmd.ListenAsync())
            {
                switch (cmdEvent)
                {
                    case StartedCommandEvent started:
                        AddLog($"🔄 Process started (PID: {started.ProcessId})");
                        break;

                    case StandardOutputCommandEvent stdOut:
                        AddLog(stdOut.Text);
                        UpdateProgressBarFromOutput(stdOut.Text);
                        break;

                    case StandardErrorCommandEvent stdErr:
                        AddLog($"⚠️ {stdErr.Text}");
                        break;

                    case ExitedCommandEvent exited:
                        AddLog($"✅ Process exited with code: {exited.ExitCode}");
                        break;
                }
            }

            // STEP 4.12: Wrap up download
            Progress = 1.0;
            ProgressText = "100%";
            StatusMessage = "Download complete!";
            AddLog("🎉 All files downloaded.");
        }
        catch (Exception ex)
        {
            // STEP 4.13: Catch and show errors
            HasError = true;
            ErrorMessage = $"Download failed: {ex.Message}";
            StatusMessage = "Download failed.";
            Progress = 0;
            ProgressText = string.Empty;
            AddLog($"❌ Exception: {ex.Message}");
        }
        finally
        {
            // STEP 4.14: Always reset busy state
            IsBusy = false;
        }
    }

    // STEP 5: Pull % progress out of yt-dlp's output
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

    // STEP 6: Add log entries (thread-safe)
    private void AddLog(string message)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            LogEntries.Add($"[{DateTime.Now:HH:mm:ss}] {message}");
            OnPropertyChanged(nameof(LogEntries));
        });
    }
}
