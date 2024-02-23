using CommunityToolkit.Mvvm.ComponentModel;


namespace GUI.ViewModels
{
    public partial class RoundEditViewModel : ObservableObject
    {
        [ObservableProperty]
        private int exerciseTime;

        [ObservableProperty]
        private int restTime;

        [ObservableProperty]
        private int exerciseHour1;

        [ObservableProperty]
        private int exerciseMinute;

        [ObservableProperty]
        private int exerciseSecond;

        [ObservableProperty]
        private int restHour;

        [ObservableProperty]
        private int restMinute;

        [ObservableProperty]
        private int restSecond;

        internal RoundEditViewModel(int eTime, int rTime)
        {
            ExerciseTime = eTime;

            ExerciseHour1 = eTime / 3600;
            ExerciseMinute = eTime - ((ExerciseHour1 * 3600) / 60);
            ExerciseSecond = eTime - ((ExerciseHour1 * 3600) + (ExerciseMinute * 60));

            RestTime = rTime;
        }

        public bool IsValid
        {
            get => ExerciseTime > 0 || RestTime > 0;    
        }
    }
}
