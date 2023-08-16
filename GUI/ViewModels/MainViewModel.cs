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
    public partial class MainViewModel : ObservableObject
    {
        
        public ObservableCollection<Routine> Routines { get; set; }

        [ObservableProperty]
        private string summary;

        public MainViewModel()
        {
            Routines =new ObservableCollection<Routine>();
            for(int i = 0; i < 60; ++i)
            {
                Routines.Add(new Routine() { Name = $"Routine {i}" });
            }
                
            

        }

    }
}
