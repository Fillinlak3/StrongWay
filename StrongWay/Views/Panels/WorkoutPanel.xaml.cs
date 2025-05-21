using Services.Logging;
using StrongWay.ViewModels;

namespace StrongWay.Views.Panels;

public partial class WorkoutPanel : ContentView
{
    public event EventHandler<Models.Video>? VideoClickedEvent;

    public WorkoutPanel(Services.VideoPlayer videoPlayer)
	{
		InitializeComponent();
        Logger.Log("WorkoutPanel", "Object created.");

        BindingContext = new WorkoutPanelViewModel(videoPlayer);
    }

    /// <summary>
    /// Display boxes on UI after WorkoutPanelViewModel successfully loaded the data.
    /// </summary>
    private void DisplayBoxes()
    {
        var viewModel = (BindingContext as WorkoutPanelViewModel)!;
        
        /*
            Load beginner, intermediate and advanced DisplayBoxes on the UI.
         */
        foreach (var item in viewModel.BeginnerBoxes)
        {
            item.VideoClickedEvent += (s, e) => VideoClickedEvent?.Invoke(this, e);
            BeginnerBoxes.Children.Add(item);
        }

        foreach (var item in viewModel.IntermediateBoxes)
        {
            item.VideoClickedEvent += (s, e) => VideoClickedEvent?.Invoke(this, e);
            IntermediateBoxes.Children.Add(item);
        }

        foreach (var item in viewModel.AdvancedBoxes)
        {
            item.VideoClickedEvent += (s, e) => VideoClickedEvent?.Invoke(this, e);
            AdvancedBoxes.Children.Add(item);
        }

        if(BeginnerBoxes.Count > 0) Logger.Log("WorkoutPanel", "BeginnerBoxes loaded.");
        if(IntermediateBoxes.Count > 0) Logger.Log("WorkoutPanel", "IntermediateBoxes loaded.");
        if(AdvancedBoxes.Count > 0) Logger.Log("WorkoutPanel", "AdvancedBoxes loaded.");
    }

    /// <summary>
    /// ViewModel loaded the data event.
    /// </summary>
    protected override void OnBindingContextChanged()
    {
        base.OnBindingContextChanged();

        // Wait until it's set to it's viewmodel.
        if (BindingContext is not WorkoutPanelViewModel)
            return;

        DisplayBoxes();
    }
}