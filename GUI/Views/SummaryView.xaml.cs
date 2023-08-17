using GUI.ViewModels;

namespace GUI.Views;

public partial class SummaryView : ContentPage
{
    public SummaryView()
    {
        
    }
    public SummaryView(SummaryViewModel viewModel)
	{
		this.BindingContext = viewModel;
		InitializeComponent();
	}
}