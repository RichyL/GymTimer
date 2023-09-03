namespace TimingService
{
    public interface IRoutineHandlingService
	{
		bool ReadRoutineInfo();

		bool WriteRoutineInfo();

		bool LoadRoutine(string routineName);
	}
}
