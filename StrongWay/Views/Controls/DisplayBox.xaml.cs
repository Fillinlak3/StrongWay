using StrongWay.ViewModels;
using System.Diagnostics;

namespace StrongWay.Views.Controls;

public partial class DisplayBox : ContentView
{
    private DisplayBoxViewModel viewModel;

    public DisplayBox(List<Models.Video> exercises)
    {
        InitializeComponent();

        viewModel = new DisplayBoxViewModel(exercises);
        BindingContext = viewModel;
    }
}