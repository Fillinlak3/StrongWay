using Services.Logging;

namespace StrongWay.Views.Pages;

public partial class BlankStartupPage : ContentPage
{
	public BlankStartupPage()
	{
		InitializeComponent();
		Logger.Log("BlankStartupPage", "Object created.");
	}
}