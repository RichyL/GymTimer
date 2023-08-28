using CommunityToolkit.Mvvm.ComponentModel;
using TimingService;


namespace GUI.ViewModels
{
    public partial class RoundViewModel : ObservableObject
    {
        [ObservableProperty]
        private int exerciseTime;

        [ObservableProperty]
        private int restTime;

        internal RoundViewModel(Round r)
        {
            ExerciseTime = r.ExerciseTime;
            restTime = r.RestTime;
        }

    }
}
