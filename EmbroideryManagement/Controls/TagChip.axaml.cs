using System.Windows.Input;
using Avalonia;
using Avalonia.Controls;
using EmbroideryManagement.Models;

namespace EmbroideryManagement.Controls;

public partial class TagChip : UserControl
{
    public static readonly StyledProperty<string> LabelProperty =
        AvaloniaProperty.Register<TagChip, string>(nameof(Label), "");

    public static readonly StyledProperty<int> CountProperty =
        AvaloniaProperty.Register<TagChip, int>(nameof(Count));

    public static readonly StyledProperty<bool> ShowCountProperty =
        AvaloniaProperty.Register<TagChip, bool>(nameof(ShowCount), true);

    public static readonly StyledProperty<TagFilterState> StateProperty =
        AvaloniaProperty.Register<TagChip, TagFilterState>(nameof(State));

    public static readonly StyledProperty<ICommand?> CommandProperty =
        AvaloniaProperty.Register<TagChip, ICommand?>(nameof(Command));

    public static readonly StyledProperty<object?> CommandParameterProperty =
        AvaloniaProperty.Register<TagChip, object?>(nameof(CommandParameter));

    public string Label
    {
        get => GetValue(LabelProperty);
        set => SetValue(LabelProperty, value);
    }

    public int Count
    {
        get => GetValue(CountProperty);
        set => SetValue(CountProperty, value);
    }

    public bool ShowCount
    {
        get => GetValue(ShowCountProperty);
        set => SetValue(ShowCountProperty, value);
    }

    public TagFilterState State
    {
        get => GetValue(StateProperty);
        set => SetValue(StateProperty, value);
    }

    public ICommand? Command
    {
        get => GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    public object? CommandParameter
    {
        get => GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    public TagChip()
    {
        InitializeComponent();
        SyncStateClasses();
    }

    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
    {
        base.OnPropertyChanged(change);
        if (change.Property == StateProperty) SyncStateClasses();
    }

    private void SyncStateClasses()
    {
        PseudoClasses.Set(":include", State == TagFilterState.Include);
        PseudoClasses.Set(":exclude", State == TagFilterState.Exclude);
    }
}