namespace GUI.Controls;

public partial class RoundViewEditor : ContentView
{ 

	//public static readonly BindableProperty ExerciseTimeProperty = BindableProperty.Create(nameof(ExerciseTime), typeof(int), typeof(RoundViewEditor),
	//	propertyChanged: (bindable, oldValue, newValue) => { 
		
	//		var control  = (RoundViewEditor)bindable;
	//		control.ExerciseTimeEntry.Text = newValue.ToString();
	//	});

	//public static readonly BindableProperty RestTimeProperty = BindableProperty.Create(nameof(RestTime), typeof(int), typeof(RoundViewEditor),
	//propertyChanged: (bindable, oldValue, newValue) => {

	//	var control = (RoundViewEditor)bindable;
	//	control.RestTimeEntry.Text = newValue.ToString();
	//});

    public static readonly BindableProperty ExerciseHourProperty = BindableProperty.Create(nameof(ExerciseHour), typeof(int), typeof(RoundViewEditor),
	propertyChanged: (bindable, oldValue, newValue) => {
	    var control = (RoundViewEditor)bindable;
		//control.ExerciseHourPicker.SelectedIndex = int.Parse(newValue.ToString()) - 1;
        }
    );

    public static readonly BindableProperty ExerciseMinuteProperty = BindableProperty.Create(nameof(ExerciseMinute), typeof(int), typeof(RoundViewEditor),
    propertyChanged: (bindable, oldValue, newValue) => {
        //var control = (RoundViewEditor)bindable;
        //control.ExerciseMinutePicker.SelectedIndex = int.Parse(newValue.ToString()) - 1;
        var control = (RoundViewEditor)bindable;
        //control.ExerciseMinute = (int)newValue;
    }
    );

    public static readonly BindableProperty ExerciseSecondProperty = BindableProperty.Create(nameof(ExerciseSecond), typeof(int), typeof(RoundViewEditor),
    propertyChanged: (bindable, oldValue, newValue) => {
        var control = (RoundViewEditor)bindable;
        //control.ExerciseSecondPicker.SelectedIndex = int.Parse(newValue.ToString()) - 1;
    }
    );


    public static readonly BindableProperty RestHourProperty = BindableProperty.Create(nameof(RestHour), typeof(int), typeof(RoundViewEditor),
   propertyChanged: (bindable, oldValue, newValue) => {
       var control = (RoundViewEditor)bindable;
       //control.RestHourPicker.SelectedIndex = int.Parse(newValue.ToString()) - 1;
   }
   );

    public static readonly BindableProperty RestMinuteProperty = BindableProperty.Create(nameof(RestMinute), typeof(int), typeof(RoundViewEditor),
    propertyChanged: (bindable, oldValue, newValue) => {
        var control = (RoundViewEditor)bindable;
        //control.RestMinutePicker.SelectedIndex = int.Parse(newValue.ToString()) - 1;
    }
    );

    public static readonly BindableProperty RestSecondProperty = BindableProperty.Create(nameof(RestSecond), typeof(int), typeof(RoundViewEditor),
    propertyChanged: (bindable, oldValue, newValue) => {
        var control = (RoundViewEditor)bindable;
        //control.RestSecondPicker.SelectedIndex = int.Parse(newValue.ToString()) - 1;
    }
    );



    public RoundViewEditor()
	{
		InitializeComponent();

		ExerciseHourPicker.ItemsSource = Enumerable.Range(0, 100).ToArray();
        ExerciseMinutePicker.ItemsSource = Enumerable.Range(0,60).ToArray();
        ExerciseSecondPicker.ItemsSource = Enumerable.Range(0, 60).ToArray();

        RestHourPicker.ItemsSource = Enumerable.Range(0, 100).ToArray();
        RestMinutePicker.ItemsSource = Enumerable.Range(0, 60).ToArray();
        RestSecondPicker.ItemsSource = Enumerable.Range(0, 60).ToArray();
    }

	public int ExerciseHour
	{
		get=>(int)GetValue(ExerciseHourProperty);
		set => SetValue(ExerciseHourProperty, value);
	}

    public int ExerciseMinute
    {
        get => (int)GetValue(ExerciseMinuteProperty);
        set => SetValue(ExerciseMinuteProperty, value);
    }

    public int ExerciseSecond
    {
        get => (int)GetValue(ExerciseSecondProperty);
        set => SetValue(ExerciseSecondProperty, value);
    }

    public int RestHour
    {
        get => (int)GetValue(RestHourProperty);
        set => SetValue(RestHourProperty, value);
    }

    public int RestMinute
    {
        get => (int)GetValue(RestMinuteProperty);
        set => SetValue(RestMinuteProperty, value);
    }

    public int RestSecond
    {
        get => (int)GetValue(RestSecondProperty);
        set => SetValue(RestSecondProperty, value);
    }

    //   public int ExerciseTime
    //{
    //	get => (int)GetValue(ExerciseTimeProperty);
    //	set => SetValue(ExerciseTimeProperty, value);
    //}

    //public int RestTime
    //{
    //	get => (int)GetValue(RestTimeProperty);
    //	set => SetValue(RestTimeProperty, value);
    //}
}