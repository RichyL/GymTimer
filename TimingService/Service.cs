using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
