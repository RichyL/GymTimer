namespace GUI.Controls;

public partial class RoundViewEditor : ContentView
{ 

	public static readonly BindableProperty ExerciseTimeProperty = BindableProperty.Create(nameof(ExerciseTime), typeof(int), typeof(RoundViewEditor),
		propertyChanged: (bindable, oldValue, newValue) => { 
		
			var control  = (RoundViewEditor)bindable;
			control.ExerciseTimeEntry.Text = newValue.ToString();
		});

	public static readonly BindableProperty RestTimeProperty = BindableProperty.Create(nameof(RestTime), typeof(int), typeof(RoundViewEditor),
	propertyChanged: (bindable, oldValue, newValue) => {

		var control = (RoundViewEditor)bindable;
		control.RestTimeEntry.Text = newValue.ToString();
	});

	public RoundViewEditor()
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