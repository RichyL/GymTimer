using System.Text;

namespace TimingService
{
	public interface ITimingService
    {
        event EventHandler<TickEventArgs> TickEvent;

        void SetRoutine(Routine routine);

        void StartRoutine();

        void StopRoutine(CancellationToken token);

        /// <summary>
        /// Restores the service so that a further call to StartRoutine will start the routine from either the intro or first round
        /// If called while the routine is running the routine is stopped first.
        /// </summary>
        void ResetRoutine();

        TickEventArgs HandleTick();
    }

    public class TickEventArgs : EventArgs
    {
        public bool IsIntro { get; set; }
        public bool IsExercise { get; set; }
        public bool IsRest { get ; set; }

        public bool IsFinished { get; set; }

        public int TimeLeftInState;
        public int CurrentRound;

		public override string ToString()
		{
			StringBuilder sb=new StringBuilder();

            //sb.Append($"INTRO - Time left:{IntroTimeLeft}  Round = {CurrentRound}. ExerciseTime = {ExerciseTimeLeft} RestTime = {RestTImeLeft}");


            if (IsIntro) { sb.Append($"ROUND = {CurrentRound} INTRO - Time left {TimeLeftInState}");  }
			if (IsExercise) { sb.Append($"ROUND = {CurrentRound} Exercising - Time left {TimeLeftInState}");  }
			if (IsRest) { sb.Append($"ROUND = {CurrentRound} Resting - Time left {TimeLeftInState}"); }
            if (IsFinished) { sb.Append($"ROUND = {CurrentRound} FINISHED"); }

            return sb.ToString();
        }
	}
}
