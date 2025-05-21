using Services.Logging;
using StrongWay.ViewModels;

namespace StrongWay.Views.Pages;

public partial class RegisterPage : ContentPage
{
	public RegisterPage(RegisterPageViewModel viewModel)
	{
		InitializeComponent();
		Logger.Log("RegisterPage", "Object created.");

		BindingContext = viewModel;
	}
}