using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Application = Microsoft.Maui.Controls.Application;

namespace YouTubeDownloaderMAUI;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        // 🚀 Use NavigationPage so we can push PlaylistHistoryPage from MainPage
        var mainPage = new NavigationPage(new MainPage());

        return new Window(mainPage);
    }
}
