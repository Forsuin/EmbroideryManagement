using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace EmbroideryManagement.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private readonly AllPatternsViewModel _patterns = new();
    private readonly CollectionsViewModel _collections = new();

    [ObservableProperty] public partial string SearchQuery { get; set; } = "";

    [ObservableProperty] public partial ViewModelBase CurrentView { get; set; }

    [ObservableProperty] public partial int SelectedTabIndex { get; set; }

    public string SearchWatermark => "Search";


    partial void OnSelectedTabIndexChanged(int value)
    {
        CurrentView = value switch
        {
            0 => _patterns,
            1 => _collections,
            _ => CurrentView
        };
    }

    partial void OnSearchQueryChanged(string value)
    {
        Debug.WriteLine("Search Query changed: {}", value);
    }

    public MainWindowViewModel()
    {
        CurrentView = _patterns;
    }
}