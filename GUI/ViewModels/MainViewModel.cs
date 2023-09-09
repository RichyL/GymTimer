using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using TimingService;

namespace GUI.ViewModels
{
	public partial class MainViewModel : ObservableObject
    {
        
        public ObservableCollection<Routine> Routines { get; set; }

        [ObservableProperty]
        private string summary;

        public MainViewModel(IRoutineHandlingService rhs)
        {
          

   //         Routines =new ObservableCollection<Routine>();

   //         Routine r = new Routine() { Name = "Test Routine", Description = "THis is a description", IntroTime = 5 };
   //         r.Rounds.Add(new Round() { ExerciseTime = 5, RestTime = 3 });
			//r.Rounds.Add(new Round() { ExerciseTime = 5, RestTime = 3 });
			//Routines.Add(r);

			//r = new Routine() { Name = "Test Routine 2", Description = "XXXX", IntroTime = 372 };
			//r.Rounds.Add(new Round() { ExerciseTime = 10, RestTime = 120 });
			//r.Rounds.Add(new Round() { ExerciseTime = 30, RestTime = 130 
			//Routines.Add(r);
			routineHandlingService = rhs;


		}

        private async Task ReadRoutineInfo()
        {
            List<Routine> routinesFromDisk = await routineHandlingService.ReadRoutineInfoAsync();

            Routines=new ObservableCollection<Routine>();
            foreach (Routine routine in routinesFromDisk)
            {
                Routines.Add(routine);
            }
        }

     
        [ObservableProperty]
		private Routine selectedRoutine;


		private readonly IRoutineHandlingService routineHandlingService;

		[RelayCommand]
        private void RoutineSelected(object item)
        {
            SelectedRoutine = (Routine)item;
			OnPropertyChanged(nameof(SelectedRoutine));

		}

        [RelayCommand]
        private async Task AddNewRoutine()
        {
            await Shell.Current.GoToAsync("editview",new Dictionary<string, object> { { "routine", new Routine() } });
        }

        [RelayCommand(CanExecute = nameof(CanEditRoutine))]
        private async Task EditRoutine()
        {
			var navigationParameter = new Dictionary<string, object> { { "routine", SelectedRoutine } };
			await Shell.Current.GoToAsync("editview", navigationParameter);
		}

        private bool CanEditRoutine()
        {
            return SelectedRoutine is not null;
        }

        [RelayCommand(CanExecute = nameof(CanEditRoutine))]
        private async Task GotoSummaryView()
        {
			var navigationParameter = new Dictionary<string, object> { { "Message", SelectedRoutine } };
			await Shell.Current.GoToAsync("summaryview", navigationParameter);
		}
    }
}
