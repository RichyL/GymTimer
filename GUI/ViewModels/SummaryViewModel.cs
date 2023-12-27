using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TimingService;

namespace GUI.ViewModels
{
	public partial class SummaryViewModel : ObservableObject, IQueryAttributable
	{
        public ObservableCollection<RoundViewModel> Rounds { get; set; }

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private string? description;

        [ObservableProperty]
        private int introTime;

        private Routine _routine;

        public SummaryViewModel()
        {
            Rounds = new ObservableCollection<RoundViewModel>();
        }

		public void ApplyQueryAttributes(IDictionary<string, object> query)
		{
            _routine = query[nameof(Routine)] as Routine;
            Name = _routine.Name;
            Description = _routine.Description;
            IntroTime = _routine.IntroTime;

            Rounds = new ObservableCollection<RoundViewModel>();
            for(int i=0; i < _routine.Rounds.Count; ++i)
            {
                Rounds.Add(new RoundViewModel( _routine.Rounds[i]) );
            }

            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(Description));
			OnPropertyChanged(nameof(IntroTime));
            OnPropertyChanged(nameof(Rounds));
		}

		[RelayCommand]
		private async Task RunRoutine()
		{
			var navigationParameter = new Dictionary<string, object> { { nameof(Routine), _routine } };
			await Shell.Current.GoToAsync(AppShell.EXERCISE_VIEW, navigationParameter);
		}

        [RelayCommand]
        private async Task EditRoutine()
        {
            var navigationParameter = new Dictionary<string, object> { { nameof(Routine), _routine } };
            await Shell.Current.GoToAsync(AppShell.EDIT_VIEW, navigationParameter);
        }
	}
}
