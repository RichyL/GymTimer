using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimingService;

namespace TimingServiceTest
{
	public class TimingTestCode
	{
		TimingClass service = new TimingClass();

        public TimingTestCode()
        {
            Routine routine = new Routine();
            routine.IntroTime = 3;
            routine.Rounds.Add(new Round(3, 3));
			routine.Rounds.Add(new Round(2, 2));

			service.TickEvent += Service_TickEvent;
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
