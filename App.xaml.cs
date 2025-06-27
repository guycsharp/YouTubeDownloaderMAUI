namespace YouTubeDownloaderMAUI;

// ✅ This marks your App class as partial to connect with the XAML definition in App.xaml
public partial class App : Application
{
    public App()
    {
        InitializeComponent(); // ✅ This wires up the XAML resources defined in App.xaml
    }

    // ✅ Override the window creation to specify which page (or Shell) to launch
    protected override Window CreateWindow(IActivationState? activationState)
    {
        // ✅ You’ve chosen to launch the app using a Shell-based structure
        // This assumes you have an AppShell.xaml file defined
        return new Window(new AppShell());
    }
}
