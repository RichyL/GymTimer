using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using TimingService;

namespace GUI.ViewModels;
public partial class EditViewModel : ObservableObject, IQueryAttributable
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

    private string routineFileName;

    [ObservableProperty]
    private int introTime;

    [ObservableProperty]
    private string message="No message currently";

    [ObservableProperty]
    private int editExerciseTime = 0;

    [ObservableProperty]
    private int editRestTime = 0;



    public ObservableCollection<RoundEditViewModel> Rounds { get; set; }


    public EditViewModel(IRoutineHandlingService timingService)
    {
        //Rounds = new ObservableCollection<RoundEditViewModel>();
        //Rounds.Add(new RoundEditViewModel(10, 20));
        _fileService = timingService;
    }

    private Routine OriginalRoutine { get; set; }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
	{
        OriginalRoutine = query[nameof(Routine)] as Routine;
        Name = OriginalRoutine.Name;
        Description = OriginalRoutine.Description;
        routineFileName  = OriginalRoutine.RoutineFileName;
		IntroTime = OriginalRoutine.IntroTime;


		Rounds = new ObservableCollection<RoundEditViewModel>();
		for (int i = 0; i < OriginalRoutine.Rounds.Count; ++i)
		{
			Rounds.Add(new RoundEditViewModel(OriginalRoutine.Rounds[i].ExerciseTime, OriginalRoutine.Rounds[i].RestTime));
		}

		OnPropertyChanged(nameof(Name));
		OnPropertyChanged(nameof(IntroTime));
		OnPropertyChanged(nameof(Rounds));
	}

	[RelayCommand]
    public async Task SaveRoutine()
    {

        Routine routine = new Routine();
        routine.Name = Name;
        routine.Description = Description;
        routine.IntroTime = IntroTime;
        routine.RoutineFileName = routineFileName;

        foreach (RoundEditViewModel model in Rounds)
        {
            routine.Rounds.Add(new Round(model.ExerciseTime, model.RestTime));
        }


        await _fileService.WriteRoutineInfoAsync(routine);
        Message = "Save successful";
        OnPropertyChanged(nameof(Message));
    }

    [RelayCommand]
    public void AddRound()
    {
        ShowAddRound=true;
    }

    [RelayCommand]
    public void RemoveRound(object o)
    {
        RoundEditViewModel roundEditViewModel  = o as RoundEditViewModel;
        Rounds.Remove(roundEditViewModel);
        OnPropertyChanged(nameof(Rounds));  
    }

    [ObservableProperty]
    private bool showAddRound;

    [ObservableProperty]
    private bool showAddRoundErrorMessage;

    [ObservableProperty]
    private string addRoundErrorMessage;
    private readonly IRoutineHandlingService _fileService;

    [RelayCommand]
    public void SaveRound()
    {
        if(EditExerciseTime ==0 && EditRestTime ==0)
        {
            AddRoundErrorMessage = "At least one of exercise time or rest time must have a value";
            ShowAddRoundErrorMessage = true;
            ShowAddRound = true;
            OnPropertyChanged(nameof(AddRoundErrorMessage));
            OnPropertyChanged(nameof(ShowAddRoundErrorMessage));
            return;
        }

        Rounds.Add(new RoundEditViewModel(EditExerciseTime, EditRestTime));
        ShowAddRound = false;
        EditExerciseTime = EditRestTime = 0;
        
    }

    //private bool CanAddRound()
    //{
    //    return rounds.Count == 0 || rounds.All(x => x.IsValid );
    //}

}

