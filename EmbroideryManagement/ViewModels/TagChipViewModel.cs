using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EmbroideryManagement.Controls;
using EmbroideryManagement.Models;

namespace EmbroideryManagement.ViewModels;

public partial class TagChipViewModel : ViewModelBase
{
    private readonly Action<TagChipViewModel>? _stateChanged;

    public TagChipViewModel(string name, int count, Action<TagChipViewModel>? stateChanged = null)
    {
        Name = name;
        Count = count;
        _stateChanged = stateChanged;
    }

    public string Name { get; }

    [ObservableProperty] public partial int Count { get; set; }
    [ObservableProperty] public partial TagFilterState State { get; set; }

    [RelayCommand]
    private void Toggle()
    {
        State = State switch
        {
            TagFilterState.None => TagFilterState.Include,
            TagFilterState.Include => TagFilterState.Exclude,
            _ => TagFilterState.None
        };
        _stateChanged?.Invoke(this);
    }

    public void Clear()
    {
        State = TagFilterState.None;
    }
}