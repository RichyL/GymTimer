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

        public Routine Routine { get; set; }

        internal RoutineViewModel(Routine r)
        {
            Routine = r;
            Name = r.Name;
            Summary = r.Summary;
            //Description = r.Description;

            ListOfRounds = new();
            for(int i = 0; i< r.Rounds.Count; i++)
            {
                Round r1 = r.Rounds[i];
				ListOfRounds.Add( new RoundViewModel(r1));    
            }

        }


        public ObservableCollection<RoundViewModel> ListOfRounds { get; set; }
    }
}
