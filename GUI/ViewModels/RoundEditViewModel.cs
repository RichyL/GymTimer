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
        private int exerciseHour;

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

            ExerciseHour = eTime / 3600;
            ExerciseMinute = eTime - ((ExerciseHour * 3600) / 60);
            ExerciseSecond = eTime - ((ExerciseHour * 3600) + (ExerciseMinute * 60));

            RestTime = rTime;
            RestHour = eTime / 3600;
            RestMinute = eTime - ((RestHour * 3600) / 60);
            RestSecond = eTime - ((RestHour * 3600) + (RestMinute * 60));

        }

        public bool IsValid
        {
            get => ExerciseTime > 0 || RestTime > 0;    
        }
    }
}
