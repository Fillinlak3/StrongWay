using StrongWay.Services;

namespace StrongWay.Views.Panels;

public partial class WorkoutPanel : ContentView
{
    private VideoPlayer _videoPlayer;

    public WorkoutPanel(VideoPlayer videoPlayer)
	{
		InitializeComponent();

        _videoPlayer = videoPlayer;

    }
}