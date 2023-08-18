using GUI.Views;

namespace GUI;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		RegisterRoutes();
	}

	private void RegisterRoutes()
	{
		Routing.RegisterRoute("mainview", typeof(MainView));
		Routing.RegisterRoute("summaryview", typeof(SummaryView));
	}
}
