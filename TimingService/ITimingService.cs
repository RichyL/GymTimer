using System.Text;

namespace TimingService
{
	public interface ITimingService
    {
        event EventHandler<TickEventArgs> TickEvent;

        void SetRoutine(Routine routine);

        void StartRoutine();

        void StopRoutine(CancellationToken token);

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

            sb.AppendLine($"ROUND = {CurrentRound}");
            if (IsIntro) { sb.Append($"INTRO - Time left {TimeLeftInState}");  }
			if (IsExercise) { sb.Append($"Exercising - Time left {TimeLeftInState}");  }
			if (IsRest) { sb.Append($"Resting - Time left {TimeLeftInState}"); }

			if (IsFinished)
            {
                sb.Append(Environment.NewLine);
                sb.Append("FINISHED!!!!");
            }

            return sb.ToString();
        }
	}
}
