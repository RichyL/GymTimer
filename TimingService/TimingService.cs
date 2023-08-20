using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace TimingService
{
	public class TimingClass: ITimingService
	{
		public event EventHandler<TickEventArgs> TickEvent;

		private Routine _routine;

		private System.Timers.Timer _timer;

		private int _introTimeLeft;
		private int _exerciseTimeLeft;
		private int _restTimeLeft;
		private int _currentRound;
		private bool _inIntroState = false;
		private bool _isFinished = false;

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
			TickEventArgs eventObject = new TickEventArgs();

			if(_inIntroState)
			{
				_introTimeLeft--;

				if (_introTimeLeft == 0) { _inIntroState = false; }
			}

			if(!_inIntroState)
			{
				
				
				if(_restTimeLeft <=0)
				{
					_currentRound++;

					if (_currentRound == 0)
					{
						_isFinished = true;
					}
					else
					{ 
					_exerciseTimeLeft = _routine.Rounds[_currentRound].ExerciseTime;
					_restTimeLeft = _routine.Rounds[_currentRound].RestTime;
					}
				}

				if (_exerciseTimeLeft <= 0) _restTimeLeft--;
				_exerciseTimeLeft--;

			}

			eventObject.IntroTimeLeft = _introTimeLeft;
			eventObject.ExerciseTimeLeft = _exerciseTimeLeft;
			eventObject.RestTImeLeft = _restTimeLeft;
			eventObject.CurrentRound = _currentRound;
			eventObject.IsFinished = _isFinished;	

			TickEvent?.Invoke(this, eventObject);
		}

		public TickEventArgs Test()
		{
			TickEventArgs eventObject = new TickEventArgs();

			if (_inIntroState)
			{
				_introTimeLeft--;

				if (_introTimeLeft == 0) { _inIntroState = false; }
			}

			if (!_inIntroState)
			{
				if (_exerciseTimeLeft >0)  _exerciseTimeLeft--;
				if (_exerciseTimeLeft <= 0) _restTimeLeft--;
				if (_restTimeLeft <= 0)
				{
					_currentRound++;

					if (_currentRound > _routine.Rounds.Count - 1)
					{
						_isFinished = true;
					}
					else
					{
						_exerciseTimeLeft = _routine.Rounds[_currentRound].ExerciseTime;
						_restTimeLeft = _routine.Rounds[_currentRound].RestTime;
					}
				}

			}

			eventObject.IntroTimeLeft = _introTimeLeft;
			eventObject.ExerciseTimeLeft = _exerciseTimeLeft;
			eventObject.RestTImeLeft = _restTimeLeft;
			eventObject.CurrentRound = _currentRound;
			eventObject.IsIntro = _inIntroState;
			eventObject.IsFinished = _isFinished;

			return eventObject;
		}

		public void StartRoutine()
		{
			if (_routine is null) throw new RoutineNotFoundException("No routine has been specified.");
			//_timer.Start();

		}

		public void StopRoutine(CancellationToken token)
		{
			_timer.Stop();
		}

		public void SetRoutine(Routine routine)
		{
			_routine = routine;

			if (_routine is null) throw new RoutineNotFoundException("No routine has been specified");
			if (routine.Rounds is null || routine.Rounds.Count == 0) throw new RoutineNotFoundException("The routine passed does not have any exercise periods defined in it");

			_introTimeLeft = routine.IntroTime;
			_exerciseTimeLeft = routine.Rounds[0].ExerciseTime;
			_restTimeLeft = routine.Rounds[0].RestTime;
			_currentRound = 0;

			_inIntroState = (_introTimeLeft > 0);
			_isFinished = false;
		}
	}
}
