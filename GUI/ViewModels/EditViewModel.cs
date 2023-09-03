using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace GUI.ViewModels;
public partial class EditViewModel : ObservableObject
{
    #region Properties for New Round Entry
    [ObservableProperty]
    private int exerciseTime;

    [ObservableProperty]
    private int restTime;
    #endregion

    [ObservableProperty]
    private string? name;

    [ObservableProperty]
    private string? description;

    [ObservableProperty]
    private int introTime;

    public ObservableCollection<RoundEditViewModel> Rounds { get; set; }



    public EditViewModel()
    {
        Rounds = new ObservableCollection<RoundEditViewModel>();
        Rounds.Add(new RoundEditViewModel(10, 20));
    }

    [RelayCommand]
    public void SaveRoutine()
    {

    }

    [RelayCommand]
    public async Task AddRound()
    {
        ShowAddRound=true;
    }

    [ObservableProperty]
    private bool showAddRound;

    [ObservableProperty]
    private bool showAddRoundErrorMessage;

    [ObservableProperty]
    private string addRoundErrorMessage;

    [RelayCommand]
    public void SaveRound()
    {
        if(ExerciseTime ==0 && RestTime ==0)
        {
            AddRoundErrorMessage = "At least one of exercise time or rest time must have a value";
            ShowAddRoundErrorMessage = true;
            ShowAddRound = true;
            OnPropertyChanged(nameof(AddRoundErrorMessage));
            OnPropertyChanged(nameof(ShowAddRoundErrorMessage));
            return;
        }

        Rounds.Add(new RoundEditViewModel(ExerciseTime, RestTime));
        ShowAddRound = false;
        ExerciseTime = RestTime = 0;
    }

    //private bool CanAddRound()
    //{
    //    return rounds.Count == 0 || rounds.All(x => x.IsValid );
    //}

}

