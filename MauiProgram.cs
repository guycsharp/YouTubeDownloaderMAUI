using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui; // ✅ Required for UseMauiCommunityToolkit()
using YouTubeDownloaderMAUI;

namespace YouTubeDownloaderMAUI;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>() // ✅ Sets the root app class
            .UseMauiCommunityToolkit() // ✅ Enables CommunityToolkit.Maui features
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug(); // ✅ Enables debug logging
#endif

        return builder.Build();
    }
}
