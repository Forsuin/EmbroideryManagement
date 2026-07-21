using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.Input;
using EmbroideryManagement.Models;

namespace EmbroideryManagement.ViewModels;

public partial class AllPatternsViewModel : ViewModelBase
{
    public string Title { get; } = "All Patterns";

    public ObservableCollection<TagChipViewModel> Tags { get; }

    public AllPatternsViewModel()
    {
        // sample tags lifted from the design's seed data
        Tags = new ObservableCollection<TagChipViewModel>(
            new (string Name, int Count)[]
                {
                    ("floral", 6), ("cross-stitch", 5), ("embroidery", 6),
                    ("beginner", 7), ("linen", 6), ("botanical", 3),
                    ("geometric", 2), ("sampler", 3)
                }
                .Select(t => new TagChipViewModel(t.Name, t.Count, OnTagStateChanged)));
    }

    private void OnTagStateChanged(TagChipViewModel tag)
    {
        ApplyFilters();
    }

    [RelayCommand]
    private void ClearAllFilters()
    {
        foreach (var tag in Tags)
        {
            tag.Clear();
            ApplyFilters();
        }
    }

    private void ApplyFilters()
    {
        var included = Tags.Where(t => t.State == TagFilterState.Include).Select(t => t.Name).ToList();
        var excluded = Tags.Where(t => t.State == TagFilterState.Exclude).Select(t => t.Name).ToList();
    }
}