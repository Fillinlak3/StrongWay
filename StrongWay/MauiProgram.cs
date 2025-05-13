using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace StrongWay;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
#pragma warning disable CA1416
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkitMediaElement()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
#pragma warning restore CA1416

#if DEBUG
		builder.Logging.AddDebug();
#endif
        // Services
        builder.Services.AddSingleton<Services.INavigationService, Services.NavigationService>();
        builder.Services.AddSingleton<Services.VideoPlayer>();
        
        // Pages
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

        // Panels
        // WorkoutPanel
        builder.Services.AddSingleton<Views.Panels.WorkoutPanel>();

        return builder.Build();
	}
}
