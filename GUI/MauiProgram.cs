using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using GUI.ViewModels;
using GUI.Views;
using Microsoft.Extensions.Logging;
using TimingService;

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
		builder.Services.AddTransient<MainView>();

		builder.Services.AddTransient<SummaryViewModel>();
        builder.Services.AddTransient<SummaryView>();
		
		builder.Services.AddTransient<ExerciseViewModel>();
		builder.Services.AddTransient<ExerciseView>();

		builder.Services.AddTransient<EditViewModel>();
		builder.Services.AddTransient<EditView>();

		builder.Services.AddSingleton<ITimingService,TimingClass>();
		

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
