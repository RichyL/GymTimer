using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TimingService;

namespace GUI.ViewModels
{
	public partial class MainViewModel : ObservableObject
    {
        
        public ObservableCollection<Routine> Routines { get; set; }

        [ObservableProperty]
        private string summary;

        public MainViewModel()
        {
          

            Routines =new ObservableCollection<Routine>();

            Routine r = new Routine() { Name = "Test Routine", Description = "THis is a description", IntroTime = 7392 };
            r.Rounds.Add(new Round() { ExerciseTime = 40, RestTime = 20 });
			r.Rounds.Add(new Round() { ExerciseTime = 30, RestTime = 30 });
			Routines.Add(r);

			r = new Routine() { Name = "Test Routine 2", Description = "XXXX", IntroTime = 372 };
			r.Rounds.Add(new Round() { ExerciseTime = 10, RestTime = 120 });
			r.Rounds.Add(new Round() { ExerciseTime = 30, RestTime = 130 });

			Routines.Add(r);
		}

        [RelayCommand]
        private async Task RoutineSelected(object item)
        {
			var navigationParameter = new Dictionary<string, object> { { "Message", item } };
            await Shell.Current.GoToAsync("summaryview", navigationParameter);
        }

    }
}
