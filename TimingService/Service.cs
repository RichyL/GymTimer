namespace TimingService
{
	public interface ITimingService
    {
        event EventHandler TickEvent;

        bool ReadRoutineInfo();

        bool WriteRoutineInfo();

        bool LoadRoutine(string routineName);

        void StartRoutine();

        void StopRoutine(CancellationToken token);
    }

    public class TickEvent : EventArgs
    {
        public bool IsIntro { get; set; }

        public Round round;


    }
}
