using System.Text;

namespace TimingService
{
	public interface ITimingService
    {
        event EventHandler<TickEventArgs> TickEvent;

        void SetRoutine(Routine routine);

        void StartRoutine();

        void StopRoutine(CancellationToken token);
    }

    public class TickEventArgs : EventArgs
    {
        public bool IsIntro { get; set; }

        public bool IsFinished { get; set; }

        public int IntroTimeLeft;
        public int ExerciseTimeLeft;
        public int RestTImeLeft;
        public int CurrentRound;

		public override string ToString()
		{
			StringBuilder sb=new StringBuilder();
            if(IsIntro)
            {
                sb.Append($"INTRO - Time left:{IntroTimeLeft} -- Round = {CurrentRound}. ExerciseTime = {ExerciseTimeLeft} RestTime = {RestTImeLeft}");
            }

            if (!IsIntro)
            {
                sb.Append($"EXERCISING: Round = {CurrentRound}. ExerciseTime = {ExerciseTimeLeft} RestTime = {RestTImeLeft}");
            }

            if (IsFinished)
            {
                sb.Append("FINISHED!!!!");
            }

            return sb.ToString();
        }
	}
}
