using GUI.ViewModels;

namespace GUI.Views;

public partial class AddRoundPopup 
{
	public AddRoundPopup(RoundEditViewModel viewModel)
	{
		this.BindingContext = viewModel;
		InitializeComponent();
	}
}