using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TimingService;

namespace GUI.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        
        public ObservableCollection<RoutineViewModel> Routines { get; set; }

        [ObservableProperty]
        private string summary;

        public MainViewModel(IRoutineHandlingService rhs)
        {


            //Routines = new ObservableCollection<Routine>();

            //Routine r = new Routine() { Name = "Test Routine", Description = "THis is a description", IntroTime = 5 };
            //r.Rounds.Add(new Round() { ExerciseTime = 5, RestTime = 3 });
            //r.Rounds.Add(new Round() { ExerciseTime = 5, RestTime = 3 });
            //Routines.Add(r);

            //r = new Routine() { Name = "Test Routine 2", Description = "XXXX", IntroTime = 372 };
            //r.Rounds.Add(new Round() { ExerciseTime = 10, RestTime = 120 });
            //r.Rounds.Add(new Round()
            //{
            //    ExerciseTime = 30,
            //    RestTime = 130
            //});
            //Routines.Add(r);

            routineHandlingService = rhs;


            //ReadRoutineInfo(result);
        }


        public async Task ReadRoutineInfoAsync()
        {
            var loadedRoutines = await routineHandlingService.ReadRoutineInfoAsync();

            Routines =new ObservableCollection<RoutineViewModel>();
            foreach (Routine routine in loadedRoutines)
            {
                Routines.Add( new RoutineViewModel(routine) );
            }
            OnPropertyChanged(nameof(Routines));
            
        }


        [RelayCommand]
        private void SelectedItem()
        {
            //SelectedRoutine = (RoutineViewModel)o;
            OnPropertyChanged(nameof(SelectedRoutine));
        }

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(EditRoutineCommand))]
        [NotifyCanExecuteChangedFor(nameof(GotoSummaryViewCommand))]
        private RoutineViewModel selectedRoutine;


		private readonly IRoutineHandlingService routineHandlingService;


        [RelayCommand]
        private async Task AddNewRoutine()
        {
            await Shell.Current.GoToAsync(AppShell.EDIT_VIEW,new Dictionary<string, object> { { nameof(Routine), new Routine() } });
        }

        private bool CanEditRoutine()
        {
            return SelectedRoutine is not null;
        }

        [RelayCommand(CanExecute = nameof(CanEditRoutine))]
        private async Task EditRoutine()
        {
			var navigationParameter = new Dictionary<string, object> { { nameof(Routine), SelectedRoutine.Routine } };
			await Shell.Current.GoToAsync(AppShell.EDIT_VIEW, navigationParameter);
		}

        
        [RelayCommand(CanExecute = nameof(CanEditRoutine))]
        private async Task GotoSummaryView()
        {
			var navigationParameter = new Dictionary<string, object> { { nameof(Routine), SelectedRoutine.Routine } };
			await Shell.Current.GoToAsync(AppShell.SUMMARY_VIEW, navigationParameter);
		}

        #region PageEvents
        public void ResetSelectedRoutine()
        {
            SelectedRoutine = null;
        }
        #endregion
    }
}
