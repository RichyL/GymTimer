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
    public partial class SummaryViewModel : ObservableObject
    {
        public ObservableCollection<Round> Rounds { get; set; }

        [ObservableProperty]
        private string name;

        public SummaryViewModel()
        {

            //this.Name = "Demo";

            Rounds = new ObservableCollection<Round>();
            for (int i = 0; i < 60; ++i)
            {
                Rounds.Add(new Round() { ExerciseTime=i*2,RestTime=i*3 });
            }

        }
    }
}
