using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TimingService;

namespace GUI.ViewModels
{
	public partial class SummaryViewModel : ObservableObject, IQueryAttributable
	{
        public ObservableCollection<Round> Rounds { get; set; }

        [ObservableProperty]
        private string? name;

        [ObservableProperty]
        private int introTime;


        private Routine _routine;


        public SummaryViewModel()
        {


            Rounds = new ObservableCollection<Round>();
            for (int i = 0; i < 60; ++i)
            {
                Rounds.Add(new Round() { ExerciseTime=i*2,RestTime=i*3 });
            }

        }

		public void ApplyQueryAttributes(IDictionary<string, object> query)
		{
            _routine = query["Message"] as Routine;
            Name = _routine.Name;
            IntroTime = _routine.IntroTime;

            Rounds = new ObservableCollection<Round>();
            for(int i=0; i < _routine.Rounds.Count; ++i)
            {
                Rounds.Add(_routine.Rounds[i]);
            }
            OnPropertyChanged(nameof(Name));
			OnPropertyChanged(nameof(IntroTime));
            OnPropertyChanged(nameof(Rounds));
		}

		[RelayCommand]
		private async Task RunRoutine()
		{
			var navigationParameter = new Dictionary<string, object> { { "Message", _routine } };
			await Shell.Current.GoToAsync("exerciseview", navigationParameter);
		}

	}
}
