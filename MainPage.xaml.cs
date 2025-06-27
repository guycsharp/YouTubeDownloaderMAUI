namespace YouTubeDownloaderMAUI;

public partial class MainPage : ContentPage
{
    private int count = 0; // ✅ Explicitly marked as private for good practice

    public MainPage()
    {
        InitializeComponent(); // ✅ Ensures XAML elements are loaded
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        // ✅ Simplified ternary logic for singular/plural text
        string timesText = count == 1 ? "time" : "times";

        // ✅ Assumes CounterBtn is defined in XAML with x:Name="CounterBtn"
        CounterBtn.Text = $"Clicked {count} {timesText}";

        // ✅ Makes app more accessible by announcing updated text
        SemanticScreenReader.Announce(CounterBtn.Text);
    }
}
