using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimingService;

public class MockRoutineHandlerService : IRoutineHandlingService
{
    public Task<Routine> LoadRoutineAsync(string routineName)
    {
        throw new NotImplementedException();
    }

    public Task<List<Routine>> ReadRoutineInfoAsync()
    {
        List<Routine> routines = new List<Routine>();

        Routine routine = new Routine() { Description = "Mock routine.Select this", IntroTime = 3 };
        routine.Rounds.Add(new Round(3, 2));
        routine.Rounds.Add(new Round(2, 2));

        routines.Add(routine);
        return Task.FromResult(routines);
    }

    public Task WriteRoutineInfoAsync(Routine routine)
    {
        throw new NotImplementedException();
    }
}
