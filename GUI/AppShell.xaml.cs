using GUI.Views;

namespace GUI;

public partial class AppShell : Shell
{
	public static string MAIN_VIEW = "mainview";
    public static string SUMMARY_VIEW = "summaryview";
    public static string EXERCISE_VIEW = "exerciseview";
    public static string EDIT_VIEW = "editview";

	public AppShell()
	{
		InitializeComponent();
		RegisterRoutes();
	}

	private void RegisterRoutes()
	{
		Routing.RegisterRoute(AppShell.MAIN_VIEW, typeof(MainView));
		Routing.RegisterRoute(AppShell.SUMMARY_VIEW, typeof(SummaryView));
		Routing.RegisterRoute(AppShell.EXERCISE_VIEW,typeof(ExerciseView));
		Routing.RegisterRoute(AppShell.EDIT_VIEW, typeof(EditView));
	}
}
