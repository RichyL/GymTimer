using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TimingService;

namespace GUI.ViewModels
{
	public partial class ExerciseViewModel : ObservableObject, IQueryAttributable
	{
		[ObservableProperty]
		private string name;

		[ObservableProperty]
		private int introTime;

		[ObservableProperty]
		private int exerciseTime;

		[ObservableProperty]
		private int restTime;

		[ObservableProperty]
		private bool isIntro;

		[ObservableProperty]
		private bool isExercising;

		[ObservableProperty]
		private bool isResting;

		[ObservableProperty]
		private bool isFinished;

		[ObservableProperty]
		private int currentRound;

		[ObservableProperty]
		private int totalRounds;

		[ObservableProperty]
		private string summary;

		public ObservableCollection<Round> Rounds { get; set; }

		private Routine _routine;

		private ITimingService _timingService;

        public ExerciseViewModel(ITimingService timingService)
        {
				_timingService = timingService;
        }


        public void ApplyQueryAttributes(IDictionary<string, object> query)
		{
			_routine = query["Message"] as Routine;
			Name = _routine.Name;
			IntroTime = _routine.IntroTime;

			Rounds = new ObservableCollection<Round>();
			for (int i = 0; i < _routine.Rounds.Count; ++i)
			{
				Rounds.Add(_routine.Rounds[i]);
			}

			//display 1-indexed 
			CurrentRound = 1;
			TotalRounds = Rounds.Count;
			Summary = $"Round {CurrentRound} of {TotalRounds}";

			OnPropertyChanged(nameof(Summary));

			OnPropertyChanged(nameof(Name));
			OnPropertyChanged(nameof(IntroTime));
			OnPropertyChanged(nameof(Rounds));
			OnPropertyChanged(nameof(TotalRounds));

			_timingService.SetRoutine(_routine);
			_timingService.TickEvent += _timingService_TickEvent;
		}

		private void _timingService_TickEvent(object sender, TickEventArgs e)
		{
			IsIntro =e.IsIntro;
			IsExercising = e.IsExercise;
			IsResting = e.IsRest;
			IsFinished = e.IsFinished;
			if (IsIntro) IntroTime = e.TimeLeftInState;
			if (IsExercising) ExerciseTime = e.TimeLeftInState;
			if (IsResting) RestTime = e.TimeLeftInState;
			
			CurrentRound = e.CurrentRound;

			Summary = $"Round {CurrentRound} of {TotalRounds}";

			OnPropertyChanged(nameof(Summary));

			OnPropertyChanged(nameof(IsIntro));
			OnPropertyChanged(nameof(IsExercising));
			OnPropertyChanged(nameof(IsResting));
			OnPropertyChanged(nameof(IsFinished));

			OnPropertyChanged(nameof(IntroTime));
			OnPropertyChanged(nameof(ExerciseTime));
			OnPropertyChanged(nameof(RestTime));
			OnPropertyChanged(nameof(Rounds));

		}

		[RelayCommand]
		private void Start()
		{
			_timingService.StartRoutine();

			//TickEventArgs tick= _timingService.HandleTick();
			//_timingService_TickEvent(this, tick);
		}


		[RelayCommand]
		private void Stop()
		{
			_timingService.StopRoutine(new CancellationToken());
		}
	}
}
