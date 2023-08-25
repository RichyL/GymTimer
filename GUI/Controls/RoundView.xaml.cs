namespace GUI.Controls;

public partial class RoundView : ContentView
{ 

	public static readonly BindableProperty ExerciseTimeProperty = BindableProperty.Create(nameof(ExerciseTime), typeof(int), typeof(RoundView),
		propertyChanged: (bindable, oldValue, newValue) => { 
		
			var control  = (RoundView)bindable;
			control.ExerciseLabel.Text = newValue.ToString();
		});

	public static readonly BindableProperty RestTimeProperty = BindableProperty.Create(nameof(RestTime), typeof(int), typeof(RoundView),
	propertyChanged: (bindable, oldValue, newValue) => {

		var control = (RoundView)bindable;
		control.RestLabel.Text = newValue.ToString();
	});

	public RoundView()
	{
		InitializeComponent();
	}

	public int ExerciseTime
	{
		get => (int)GetValue(ExerciseTimeProperty);
		set => SetValue(ExerciseTimeProperty, value);
	}

	public int RestTime
	{
		get => (int)GetValue(RestTimeProperty);
		set => SetValue(RestTimeProperty, value);
	}
}