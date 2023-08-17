using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using GUI.ViewModels;
using GUI.Views;
using Microsoft.Extensions.Logging;

namespace GUI;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkitCore()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		//builder.Services.AddSingleton(ITimingService,)
		builder.Services.AddTransient<MainViewModel>();
		builder.Services.AddTransient<MainPage>();

		builder.Services.AddTransient<SummaryViewModel>();
        builder.Services.AddTransient<SummaryView>();


#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
