using Services.Logging;

namespace StrongWay.Views.Panels;

public partial class VideoPopupOverlay : ContentView
{
	public VideoPopupOverlay()
	{
		InitializeComponent();

        Logger.Log("VideoPopupOverlay", "Object created.");
    }

    private void CloseOverlay(object sender, TappedEventArgs e)
    {
        this.IsVisible = false;
        Logger.Log("VideoPopupOverlay", "Overlay closed.");
    }
}