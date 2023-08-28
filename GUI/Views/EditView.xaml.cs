using GUI.ViewModels;

namespace GUI.Views;

public partial class EditView : ContentPage
{
	public EditView(EditViewModel viewModel)
	{
		this.BindingContext = viewModel;
		InitializeComponent();
	}
}