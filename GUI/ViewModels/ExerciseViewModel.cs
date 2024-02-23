using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Graphics.Canvas.Effects;
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
		private string summary = NOT_STARTED_SUMMARY;

		[ObservableProperty]
		private int currentTime;

		[ObservableProperty]
		private string fillColour;

		private int currentRound;
		private int totalRounds;

		private static string NOT_STARTED = "Ready to start";
		private static string INTRO = "Starting";
		private static string EXERCISING = "Exercise";
		private static string RESTING = "Rest";
		private static string FINISHED = "Finished routine";

		private static string NOT_STARTED_SUMMARY = "Press start to begin routine";
        private static string INTRO_SUMMARY= "Routine starting";


        [ObservableProperty]
		private string state;

		public ObservableCollection<Round> Rounds { get; set; }

		private Routine _routine;

		private ITimingService _timingService;

		private int originalIntroTime;
		private int originalExerciseTime;
		private int originalRestTime;

        public ExerciseViewModel(ITimingService timingService)
        {
				_timingService = timingService;
        }


        public void ApplyQueryAttributes(IDictionary<string, object> query)
		{
			_routine = query[nameof(Routine)] as Routine;
			Name = _routine.Name;
			IntroTime = _routine.IntroTime;
			originalIntroTime = IntroTime;
            IsIntro = IntroTime > 0;


			Rounds = new ObservableCollection<Round>();
			for (int i = 0; i < _routine.Rounds.Count; ++i)
			{
				Rounds.Add(_routine.Rounds[i]);
			}
			totalRounds = Rounds.Count;



            SetState();

            OnPropertyChanged(nameof(Summary));
			OnPropertyChanged(nameof(Name));
			OnPropertyChanged(nameof(IntroTime));
			OnPropertyChanged(nameof(Rounds));

			_timingService.SetRoutine(_routine);
			_timingService.TickEvent += _timingService_TickEvent;
		}

		private void _timingService_TickEvent(object sender, TickEventArgs e)
		{
			IsIntro =e.IsIntro;
			IsExercising = e.IsExercise;
			IsResting = e.IsRest;
			IsFinished = e.IsFinished;

			//display is 1-indexed
			currentRound = e.CurrentRound;
			if (IsIntro) IntroTime = e.TimeLeftInState;
			if (IsExercising) ExerciseTime = e.TimeLeftInState;
			if (IsResting) RestTime = e.TimeLeftInState;
			
			
			//if(currentRound != e.CurrentRound)
			//{
			//	if(IsExercising) originalExerciseTime=e.TimeLeftInState;
			//	if(IsResting) originalRestTime = e.TimeLeftInState;
			//}


            if (IsIntro)
            {
				Summary = INTRO_SUMMARY;
            }

            if (!IsIntro)
            {
                Summary = $"Round {currentRound} of {totalRounds}";
            }

            SetState();

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

		private void SetState()
		{
			if (IsIntro) { 
				State = INTRO;
				CurrentTime = IntroTime;
            };

			if(IsExercising) { 
				State = EXERCISING;
				CurrentTime = ExerciseTime;
            }
			if(IsResting) { 
				State = RESTING;
				CurrentTime = RestTime;
            }

			if(IsFinished)
			{
				State = FINISHED;
				CurrentTime = 0;
				
            }

			OnPropertyChanged(nameof(FillColour));
			OnPropertyChanged(nameof(State));
			OnPropertyChanged(nameof(CurrentTime));

		}

		[RelayCommand]
		private void Start()
		{
			/*_timingService.StartRoutine()*/;

			TickEventArgs tick = _timingService.HandleTick();
			_timingService_TickEvent(this, tick);
		}


		[RelayCommand]
		private void Stop()
		{
			_timingService.StopRoutine(new CancellationToken());
		}

		[RelayCommand]
		private void Reset()
		{
			_timingService.ResetRoutine();
			Summary = NOT_STARTED_SUMMARY;
			State = NOT_STARTED;

            OnPropertyChanged(nameof(Summary));
			OnPropertyChanged(nameof(State));


        }
	}
}
