namespace TimingService
{
    public interface IRoutineHandlingService
	{
        Task<List<Routine>> ReadRoutineInfoAsync();

        Task WriteRoutineInfoAsync(Routine routine);

		Task<Routine> LoadRoutineAsync(string routineName);
	}
}
