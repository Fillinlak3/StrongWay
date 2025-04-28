using Microsoft.Extensions.Logging;

namespace StrongWay;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif
        // Services
        builder.Services.AddSingleton<Services.INavigationService, Services.NavigationService>();
        
        // BlankPage - For startup only.
        builder.Services.AddSingleton<Views.Pages.BlankStartupPage>();
        // MainPage
        builder.Services.AddSingleton<Views.Pages.MainPage>();
        // LoginPage
        builder.Services.AddSingleton<Views.Pages.LoginPage>();
        builder.Services.AddSingleton<ViewModels.LoginPageViewModel>();
        // RegisterPage
        builder.Services.AddSingleton<Views.Pages.RegisterPage>();
        builder.Services.AddSingleton<ViewModels.RegisterPageViewModel>();

        return builder.Build();
	}
}
