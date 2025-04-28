using StrongWay.ViewModels;

namespace StrongWay.Views.Pages;

public partial class RegisterPage : ContentPage
{
	public RegisterPage(RegisterPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}