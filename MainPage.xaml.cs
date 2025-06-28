using Microsoft.Maui.Controls;
using YouTubeDownloaderMAUI.ViewModel;

namespace YouTubeDownloaderMAUI;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnViewHistoryClicked(object sender, EventArgs e)
    {
        if (BindingContext is MainViewModel vm)
        {
            await Navigation.PushAsync(new PlaylistHistoryPage(vm.PlaylistHistoryPath));
        }
    }
}
