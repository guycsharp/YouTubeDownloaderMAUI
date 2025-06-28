using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Collections.ObjectModel; // 🆕 For ObservableCollection<T>
using CliWrap;
using CliWrap.EventStream;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using YouTubeDownloaderMAUI.Services;

namespace YouTubeDownloaderMAUI.ViewModel;

// 🎯 This is your main view model — it handles all logic for the UI
public partial class MainViewModel : ObservableObject
{
    // =====================
    // 🔗 UI-Bound Properties
    // =====================

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

    // 🆕 ObservableCollection automatically notifies the UI when changed
    [ObservableProperty]
    private ObservableCollection<string> _logEntries = new();

    [ObservableProperty]
    private string _errorMessage = string.Empty;

    [ObservableProperty]
    private bool _hasError;

    [ObservableProperty]
    private List<string> _formats = new() { "MP4 (Video)", "MP3 (Audio)" };

    [ObservableProperty]
    private string _selectedFormat = "MP4 (Video)";

    [ObservableProperty]
    private string _destinationFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

    [ObservableProperty]
    private bool _overwriteExisting = false;

    // ================
    // 📁 Folder Picker
    // ================

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

    // ======================
    // 📋 Clipboard Integration
    // ======================

    [RelayCommand]
    private async Task Paste()
    {
        PlaylistUrl = await Clipboard.Default.GetTextAsync() ?? string.Empty;
        AddLog("📋 Pasted from clipboard");
    }

    [RelayCommand]
    private async Task CopyError()
    {
        if (!string.IsNullOrWhiteSpace(ErrorMessage))
        {
            await Clipboard.Default.SetTextAsync(ErrorMessage);
            AddLog("📎 Error copied to clipboard");
        }
    }

    // =====================
    // 📦 Start the download
    // =====================

    [RelayCommand]
    private async Task Download()
    {
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

            var outputTemplate = Path.Combine(DestinationFolder, "%(playlist_title)s", "%(playlist_index)s - %(title)s.%(ext)s");

            string arguments = SelectedFormat == "MP4 (Video)"
                ? $"-f \"bestvideo+bestaudio\" --merge-output-format mp4 --embed-thumbnail --embed-metadata"
                : $"-x --audio-format mp3 --embed-thumbnail";

            arguments += $" -o \"{outputTemplate}\"";

            if (!OverwriteExisting)
            {
                arguments += " --no-overwrites";
            }

            arguments += $" \"{PlaylistUrl}\"";

            AddLog($"▶ Running yt-dlp with args: {arguments}");

            var cmd = Cli.Wrap(ytDlpPath)
                         .WithArguments(arguments)
                         .WithWorkingDirectory(AppContext.BaseDirectory)
                         .WithEnvironmentVariables(env =>
                             env.Set("PATH", $"{Environment.GetEnvironmentVariable("PATH")};{ffmpegBinPath}"));

            AddLog("🚀 Download started...");

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

            Progress = 1.0;
            ProgressText = "100%";
            StatusMessage = "Download complete!";
            AddLog("🎉 All files downloaded.");
        }
        catch (Exception ex)
        {
            HasError = true;
            ErrorMessage = $"Download failed: {ex.Message}";
            StatusMessage = "Download failed.";
            Progress = 0;
            ProgressText = string.Empty;
            AddLog($"❌ Exception: {ex.Message}");
        }
        finally
        {
            IsBusy = false;
        }
    }

    // ===========================
    // 📊 yt-dlp Output Progress %
    // ===========================

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

    // ========================
    // 🧾 Timestamped Log Entry
    // ========================

    private void AddLog(string message)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            LogEntries.Add($"[{DateTime.Now:HH:mm:ss}] {message}");
        });
    }
}
