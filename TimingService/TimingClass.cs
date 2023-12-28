using System.Timers;

namespace TimingService
{
    public class TimingClass: ITimingService
	{
		public event EventHandler<TickEventArgs> TickEvent;

		private Routine _routine;

		private System.Timers.Timer _timer;

	
        public TimingClass()
        {
            _routine = new Routine();
			_routine.Name = "Routing from service";
			_routine.IntroTime = 10;

			_routine.Rounds.Add(new Round() { ExerciseTime = 10, RestTime = 5 });
			_routine.Rounds.Add(new Round() { ExerciseTime = 8, RestTime = 3 });
			_timer = new System.Timers.Timer(1000);
			_timer.Elapsed += _timer_Elapsed;
		}

		public void _timer_Elapsed(object sender, ElapsedEventArgs e)
		{
			TickEventArgs eventObject = HandleTick();
			TickEvent?.Invoke(this, eventObject);
		}

		public TickEventArgs HandleTick()
		{
			TickEventArgs eventObject = new TickEventArgs();

			bool inTransition = false;

			//Transition from Intro to Exercise
			if (_isIntro && _countDownTime ==0)
			{
				_isIntro = false;
				_isExercise = true;
				_isRest = false;

				//Put exercise time into _countDownTime
				_countDownTime = _routine.Rounds[_roundCount].ExerciseTime;

                eventObject.IsIntro = _isIntro;
                eventObject.IsExercise = _isExercise;
                eventObject.IsRest = _isRest;
                eventObject.TimeLeftInState = _countDownTime;
				eventObject.CurrentRound = _roundCount + 1;
				inTransition = true;

                //return eventObject;
			}

			//transition from Exercise To Rest
			if(_isExercise && _countDownTime ==0 )
			{
				_isIntro=false;
				_isExercise = false;
				_isRest = true;

				//Put rest time into _countDownTime
				_countDownTime = _routine.Rounds[_roundCount].RestTime;

                eventObject.IsIntro = _isIntro;
                eventObject.IsExercise = _isExercise;
                eventObject.IsRest = _isRest;
                eventObject.TimeLeftInState = _countDownTime;
                eventObject.CurrentRound = _roundCount+1;
                inTransition = true;

                //return eventObject;
			}

			//transition from Rest to Exercise
			if(_isRest && _countDownTime ==0 )
			{
				_isIntro=false;
				_isExercise = true;
				_isRest = false;
                _roundCount++;

				if(_roundCount > _routine.Rounds.Count - 1)
				{
					//handle possible routine finish here
					_isIntro = false; _isExercise = false; _isRest = false; _isFinished = true;
                    eventObject.IsIntro = _isIntro;
                    eventObject.IsExercise = _isExercise;
                    eventObject.IsRest = _isRest;
                    eventObject.TimeLeftInState = 0;
                    eventObject.IsFinished=_isFinished;
					eventObject.CurrentRound = _routine.Rounds.Count;
                    inTransition = true;
                }
				else
				{
                    //Put next round exercise time into _countDownTime
                    _countDownTime = _routine.Rounds[_roundCount].ExerciseTime;

                    eventObject.IsIntro = _isIntro;
                    eventObject.IsExercise = _isExercise;
                    eventObject.IsRest = _isRest;
                    eventObject.TimeLeftInState = _countDownTime;
                    eventObject.CurrentRound = _roundCount + 1;
                    inTransition = true;
                }

			
				//return eventObject;
			}


            // if no change in state then event object is generated here
            if (!inTransition)
            {

                eventObject.IsIntro = _isIntro;
                eventObject.IsExercise = _isExercise;
                eventObject.IsRest = _isRest;
                eventObject.TimeLeftInState = _countDownTime;
                //need to display 1-indexed round number to the user
                eventObject.CurrentRound = (_isIntro) ? 0 : _roundCount + 1;
            }

            _countDownTime--;
            return eventObject;
		}


	

		public void StartRoutine()
		{
			if (_routine is null) throw new RoutineNotFoundException("No routine has been specified.");
			_timer.Start();

		}

		public void StopRoutine(CancellationToken token)
		{
			_timer.Stop();
		}

		int _countDownTime = 0;
		bool _isIntro = false;
		bool _isExercise = false;
		bool _isRest = false;
		bool _isFinished = false;
		int _roundCount = 0;

		public void SetRoutine(Routine routine)
		{
			_routine = routine;
			_roundCount = 0;

			if (_routine is null) throw new RoutineNotFoundException("No routine has been specified");
			if (routine.Rounds is null || routine.Rounds.Count == 0) throw new RoutineNotFoundException("The routine passed does not have any exercise periods defined in it");


			if (_routine.IntroTime > 0)
			{
				_countDownTime = routine.IntroTime;
				_isIntro = true;
			}
			else if (_routine.Rounds[0].ExerciseTime > 0)
			{
				_countDownTime = _routine.Rounds[0].ExerciseTime;
				_isExercise = true;
			}


			//_introTimeLeft = routine.IntroTime - 1;
			//_exerciseTimeLeft = routine.Rounds[0].ExerciseTime;
			//_restTimeLeft = routine.Rounds[0].RestTime;
			//_currentRound = 0;

			//_inIntroState = (_introTimeLeft > 0);
			//_isFinished = false;

			
			//_introClicks = (_introTimeLeft > 0)? _introTimeLeft - 1:0;
			//_exerciseClicks = (_introTimeLeft > 0) ? routine.Rounds[0].ExerciseTime - 1:;
			//_restClicks = routine.Rounds[0].RestTime;
		}

        public void ResetRoutine()
        {
			StopRoutine(new CancellationToken() );
			SetRoutine(_routine);

        }
    }
}
