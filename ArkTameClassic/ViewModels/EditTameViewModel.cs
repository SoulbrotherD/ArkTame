using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using AdonisUI.Controls;
using ArkTameClassic.Framework;
using ArkTameClassic.Services;

namespace ArkTameClassic.ViewModels;

public class EditTameViewModelClassic : ViewModelBase
{
    private string? _name;
    private TameInfo? _selectedTame;
    private Sex? _selectedSex;
    private int? _health;
    private int? _stamina;
    private int? _oxygen;
    private int? _food;
    private int? _weight;
    private int? _meleeDamage;
    private int? _movementSpeed;

    public bool IsMale => SelectedSex == Sex.Male;

    public bool IsFemale => SelectedSex == Sex.Female;

    public static EditTameViewModelClassic Design => new(null);

    public IReadOnlyList<TameInfo>? AvailableTames { get; }

    public int Level => GetLevel();

    public ICommand SetSexCommand { get; }

    public ICommand SaveCommand { get; }

    public string? Name
    {
        get => _name;
        set => SetField(ref _name, value);
    }

    public TameInfo? SelectedTame
    {
        get => _selectedTame;
        set => SetField(ref _selectedTame, value);
    }

    public Sex? SelectedSex
    {
        get => _selectedSex;
        set
        {
            SetField(ref _selectedSex, value);
            OnPropertyChanged(nameof(IsFemale));
            OnPropertyChanged(nameof(IsMale));
        }
    }

    public int? Health
    {
        get => _health;
        set
        {
            SetField(ref _health, value);
            OnPropertyChanged(nameof(Level));
        }
    }

    public int? Stamina
    {
        get => _stamina;
        set
        {
            SetField(ref _stamina, value);
            OnPropertyChanged(nameof(Level));
        }
    }

    public int? Oxygen
    {
        get => _oxygen;
        set
        {
            SetField(ref _oxygen, value);
            OnPropertyChanged(nameof(Level));
        }
    }

    public int? Food
    {
        get => _food;
        set
        {
            SetField(ref _food, value);
            OnPropertyChanged(nameof(Level));
        }
    }

    public int? Weight
    {
        get => _weight;
        set
        {
            SetField(ref _weight, value);
            OnPropertyChanged(nameof(Level));
        }
    }

    public int? MeleeDamage
    {
        get => _meleeDamage;
        set
        {
            SetField(ref _meleeDamage, value);
            OnPropertyChanged(nameof(Level));
        }
    }

    public int? MovementSpeed
    {
        get => _movementSpeed;
        set
        {
            SetField(ref _movementSpeed, value);
            OnPropertyChanged(nameof(Level));
        }
    }

    public EditTameViewModelClassic(TameService? tameService)
    {
        AvailableTames = tameService?.GetTameInfosFromFile();
        SetSexCommand = new RelayCommand<Sex>(SetSex);
        SaveCommand = new RelayCommand(Save);
    }

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
        SelectedSex = sex;
    }

    private async void Save()
    {
        await Task.Delay(3000);
        MessageBox.Show("Saved!");
    }
}