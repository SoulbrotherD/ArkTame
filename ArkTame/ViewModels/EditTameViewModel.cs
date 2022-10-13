using System.Collections.Generic;
using System.Threading.Tasks;
using ArkTame.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using MessageBox = AdonisUI.Controls.MessageBox;
using MessageBoxButton = AdonisUI.Controls.MessageBoxButton;
using MessageBoxImage = AdonisUI.Controls.MessageBoxImage;

namespace ArkTame.ViewModels;

public partial class EditTameViewModel : ObservableObject
{
    public bool IsMale => SelectedSex == Sex.Male;

    public bool IsFemale => SelectedSex == Sex.Female;

    public static EditTameViewModel Design { get; } = new(null);

    public IReadOnlyList<TameInfo>? AvailableTames { get; }

    public int Level => GetLevel();

    public EditTameViewModel(TameService? tameService)
    {
        AvailableTames = tameService?.GetTameInfosFromFile();
    }

    [ObservableProperty]
    private string? _name;

    [ObservableProperty]
    private TameInfo? _selectedTame;

    [ObservableProperty]
    private Sex? _selectedSex;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Level))]
    private int? _health;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Level))]
    private int? _stamina;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Level))]
    private int? _oxygen;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Level))]
    private int? _food;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Level))]
    private int? _weight;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Level))]
    private int? _meleeDamage;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Level))]
    private int? _movementSpeed;

    private int GetLevel()
    {
        var result = 1 +
            (Health ?? 0) +
            (Stamina ?? 0) +
            (Oxygen ?? 0) +
            (Food ?? 0) +
            (Weight ?? 0) +
            (MeleeDamage ?? 0) +
            (MovementSpeed ?? 0);

        return result;
    }

    private void SetSex(Sex sex)
    {
    }

    private async void Save()
    {
        await Task.Delay(6000);
        MessageBox.Show("Saved", "Saved", MessageBoxButton.OK, MessageBoxImage.Information);
    }
}