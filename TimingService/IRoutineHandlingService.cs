using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimingService
{
	public interface IRoutineHandlingService
	{
		bool ReadRoutineInfo();

		bool WriteRoutineInfo();

		bool LoadRoutine(string routineName);
	}
}
