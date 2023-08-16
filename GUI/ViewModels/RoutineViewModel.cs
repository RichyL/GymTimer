using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimingService;

namespace GUI.ViewModels
{
    public partial class RoutineViewModel : ObservableObject
    {
        public RoutineViewModel(Routine r)
        {
            Name = r.Name;
            Summary = r.Name;
        }

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private string summary;
    }
}
