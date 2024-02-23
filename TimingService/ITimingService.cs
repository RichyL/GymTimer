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
}
