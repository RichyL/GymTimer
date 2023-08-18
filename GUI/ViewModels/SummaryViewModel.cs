using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TimingService;

namespace GUI.ViewModels
{
    public partial class SummaryViewModel : ObservableObject, IQueryAttributable
	{
        public ObservableCollection<Round> Rounds { get; set; }

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private int intro;

        private Routine _routine;


        public SummaryViewModel()
        {

            //this.Name = "Demo";

            Rounds = new ObservableCollection<Round>();
            for (int i = 0; i < 60; ++i)
            {
                Rounds.Add(new Round() { ExerciseTime=i*2,RestTime=i*3 });
            }

        }

		public void ApplyQueryAttributes(IDictionary<string, object> query)
		{
            _routine = query["Message"] as Routine;
            Name = _routine.Name;
            Intro = _routine.IntroTime;
            OnPropertyChanged(nameof(Name));
			OnPropertyChanged(nameof(Intro));
		}
	}
}
