using StrongWay.ViewModels;

namespace StrongWay.Views.Controls;

public partial class DisplayBox : ContentView
{
    private DisplayBoxViewModel viewModel;
    public event EventHandler<Models.Video>? VideoClickedEvent;

    public DisplayBox(List<Models.Video> exercises)
    {
        InitializeComponent();

        Exercise_1.Video_Exercise = exercises[0];
        Exercise_2.Video_Exercise = exercises[1];

        Exercise_1.VideoClickedEvent += (s, e) => VideoClickedEvent?.Invoke(this, e);
        Exercise_2.VideoClickedEvent += (s, e) => VideoClickedEvent?.Invoke(this, e);

        viewModel = new DisplayBoxViewModel(exercises);
        BindingContext = viewModel;
    }
}