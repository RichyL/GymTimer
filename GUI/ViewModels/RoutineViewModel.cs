using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using TimingService;


namespace GUI.ViewModels
{
    public partial class RoutineViewModel : ObservableObject
    {
		[ObservableProperty]
		private string name;

		[ObservableProperty]
		private string summary;

		[ObservableProperty]
		private string description;

        private string RoutineFileName { get; set; }

        public Routine Routine{ get; set; }

        public RoutineViewModel(Routine r)
        { 
            Routine = r;
            Name = Routine.Name;
            Summary = Routine.Summary;
            Description = Routine.Description;
            RoutineFileName = Routine.RoutineFileName;

            ListOfRounds = new();
            for(int i = 0; i< Routine.Rounds.Count; i++)
            {
                Round r1 = Routine.Rounds[i];
				ListOfRounds.Add( new RoundViewModel(r1) );    
            }

        }

        public ObservableCollection<RoundViewModel> ListOfRounds { get; set; }
    }
}
