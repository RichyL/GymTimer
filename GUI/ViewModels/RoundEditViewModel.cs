using CommunityToolkit.Mvvm.ComponentModel;
using TimingService;


namespace GUI.ViewModels
{
    public partial class RoundEditViewModel : ObservableObject
    {
        [ObservableProperty]
        private int exerciseTime;

        [ObservableProperty]
        private int restTime;

        internal RoundEditViewModel(int eTime, int rTime)
        {
            ExerciseTime = eTime;
            RestTime = rTime;
        }

        public bool IsValid
        {
            get => ExerciseTime > 0 || RestTime > 0;    
        }
    }
}
