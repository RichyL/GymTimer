using TimingService;

namespace TimingServiceTest
{
    public class TimingTestCode
	{
		TimingClass service = new TimingClass();

        public TimingTestCode()
        {
            Routine routine = new Routine();
            routine.IntroTime = 10;
            routine.Rounds.Add(new Round(3, 0));
			routine.Rounds.Add(new Round(2, 0));

			//service.TickEvent += Service_TickEvent;
			service.SetRoutine(routine);
		}

		public void Start()
		{
			//service.StartRoutine();
			TickEventArgs args = service.HandleTick();
			Console.WriteLine(args);

			args = service.HandleTick();
			Console.WriteLine(args);

			args = service.HandleTick();
			Console.WriteLine(args);

			args = service.HandleTick();
			Console.WriteLine(args);

            Console.WriteLine("Service to be reset");
            service.ResetRoutine();
            Console.WriteLine("Service reset");

            args = service.HandleTick();
			Console.WriteLine(args);

			args = service.HandleTick();
			Console.WriteLine(args);

			args = service.HandleTick();
			Console.WriteLine(args);

			args = service.HandleTick();
			Console.WriteLine(args);

			args = service.HandleTick();
			Console.WriteLine(args);

			args = service.HandleTick();
			Console.WriteLine(args);

			args = service.HandleTick();
			Console.WriteLine(args);

			args = service.HandleTick();
			Console.WriteLine(args);

			args = service.HandleTick();
			Console.WriteLine(args);


			args = service.HandleTick();
			Console.WriteLine(args);

            args = service.HandleTick();
            Console.WriteLine(args);

        }

		private void Service_TickEvent(object? sender, TickEventArgs e)
		{
            Console.WriteLine(e.ToString());
        }
	}
}
