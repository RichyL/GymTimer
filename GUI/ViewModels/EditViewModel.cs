using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GUI.Views;
using Mopups.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.ViewModels;
public partial class EditViewModel : ObservableObject
{
    [ObservableProperty]
    private string? name;

    [ObservableProperty]
    private string? description;

    [ObservableProperty]
    private int introTime;
    private readonly IPopupNavigation _popupService;

    public ObservableCollection<RoundEditViewModel> Rounds { get; set; }



    public EditViewModel(IPopupNavigation popupService)
    {
        Rounds = new ObservableCollection<RoundEditViewModel>();
        Rounds.Add(new RoundEditViewModel(10, 20));
        _popupService = popupService;
    }

    [RelayCommand]
    public void SaveRoutine()
    {

    }

    [RelayCommand]
    public async Task AddRound()
    {
        Rounds.Add(new RoundEditViewModel(0, 0));
        await _popupService.PushAsync(new AddRoundPopup());
    }

    //private bool CanAddRound()
    //{
    //    return rounds.Count == 0 || rounds.All(x => x.IsValid );
    //}

}

