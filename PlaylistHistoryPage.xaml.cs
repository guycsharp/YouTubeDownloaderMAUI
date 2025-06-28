using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using YouTubeDownloaderMAUI.Models;

namespace YouTubeDownloaderMAUI;

public partial class PlaylistHistoryPage : ContentPage
{
    public PlaylistHistoryPage(string historyFilePath)
    {
        InitializeComponent();
        LoadHistoryAsync(historyFilePath);
    }

    // 🧠 Load playlist history from JSON file and bind to UI
    private async void LoadHistoryAsync(string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                string json = await File.ReadAllTextAsync(filePath);
                var data = JsonSerializer.Deserialize<List<PlaylistHistoryEntry>>(json);

                HistoryList.ItemsSource = data ?? new List<PlaylistHistoryEntry>();
                HistoryStatus.Text = $"Loaded {data?.Count ?? 0} playlist{(data?.Count == 1 ? "" : "s")}.";
            }
            else
            {
                HistoryStatus.Text = "No history found.";
                HistoryList.ItemsSource = new List<PlaylistHistoryEntry>();
            }
        }
        catch (Exception ex)
        {
            HistoryStatus.Text = $"Error loading history: {ex.Message}";
        }
    }
}
