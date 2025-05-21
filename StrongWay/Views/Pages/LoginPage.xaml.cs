using Services.Logging;
using StrongWay.ViewModels;

namespace StrongWay.Views.Pages;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginPageViewModel viewModel)
	{
		InitializeComponent();
		Logger.Log("LoginPage", "Object created.");

		BindingContext = viewModel;
	}
}