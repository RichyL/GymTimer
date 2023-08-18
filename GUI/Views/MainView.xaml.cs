using GUI.ViewModels;

namespace GUI.Views;

public partial class MainView : ContentPage
{
    public MainView()
    {
            
    }

    public MainView(MainViewModel viewModel)
	{
		this.BindingContext = viewModel;
		InitializeComponent();
	}
}