using GUI.ViewModels;

namespace GUI.Views;

public partial class MainPage : ContentPage
{

	public MainPage(MainViewModel viewModel)
	{
		this.BindingContext = viewModel;
		InitializeComponent();
	}
	
}

