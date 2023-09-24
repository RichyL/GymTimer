using AsyncAwaitBestPractices;
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

    protected override void OnAppearing()
    {
        base.OnAppearing();
        MainViewModel mainViewModel = (MainViewModel)BindingContext;
        mainViewModel.ReadRoutineInfoAsync().SafeFireAndForget();
    }
}