using GUI.ViewModels;

namespace GUI.Views;

public partial class ExerciseView : ContentPage
{
    public ExerciseView()
    {
        
    }
    public ExerciseView(ExerciseViewModel viewModel)
	{
		this.BindingContext = viewModel;
		InitializeComponent();
	}
}