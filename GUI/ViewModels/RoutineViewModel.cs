using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

		public RoutineViewModel(Routine r)
        {
            Name = r.Name;
            Summary = r.Summary;
            //Description = r.Description;
            

            for(int i = 0; i< r.Rounds.Count; i++)
            {
                Rounds.Add(Rounds.ElementAt(i));    
            }

        }


        public ObservableCollection<List<Round>> Rounds { get; set; } = new();
    }
}
