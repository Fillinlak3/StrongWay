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
        builder.Logging.SetMinimumLevel(LogLevel.Error);
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
        builder.Services.AddTransient<Views.Pages.LoginPage>();
        builder.Services.AddTransient<ViewModels.LoginPageViewModel>();
        // RegisterPage
        builder.Services.AddTransient<Views.Pages.RegisterPage>();
        builder.Services.AddTransient<ViewModels.RegisterPageViewModel>();

        // Panels
        // WorkoutPanel
        builder.Services.AddTransient<Views.Panels.WorkoutPanel>();

        return builder.Build();
	}
}
