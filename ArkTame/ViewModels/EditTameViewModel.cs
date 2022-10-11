using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using ArkTame.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ArkTame.ViewModels;

public partial class EditTameViewModel : ObservableValidator
{
    public bool IsMale => _selectedSex == Sex.Male;

    public bool IsFemale => _selectedSex == Sex.Female;

    public static EditTameViewModel Design { get; } = new(null);

    public IReadOnlyList<TameInfo>? AvailableTames { get; }

    public int Level => GetLevel();

    [ObservableProperty]
    [Required]
    [MinLength(2)]
    [NotifyDataErrorInfo]
    [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
    private string? _name;

    [ObservableProperty]
    [Required]
    [NotifyDataErrorInfo]
    [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
    private TameInfo? _selectedTame;
    
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsFemale))]
    [NotifyPropertyChangedFor(nameof(IsMale))]
    [NotifyDataErrorInfo]
    [Required]
    [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
    private Sex? _selectedSex;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Level))]
    [Range(0, 100)]
    [Required]
    [NotifyDataErrorInfo]
    [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
    private int? _health;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Level))]
    [Range(0, 100)]
    [Required]
    [NotifyDataErrorInfo]
    [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
    private int? _stamina;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Level))]
    [Range(0, 100)]
    [Required]
    [NotifyDataErrorInfo]
    [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
    private int? _oxygen;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Level))]
    [Range(0, 100)]
    [Required]
    [NotifyDataErrorInfo]
    [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
    private int? _food;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Level))]
    [Range(0, 100)]
    [Required]
    [NotifyDataErrorInfo]
    [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
    private int? _weight;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Level))]
    [Range(0, 100)]
    [Required]
    [NotifyDataErrorInfo]
    private int? _meleeDamage;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Level))]
    [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
    [Range(0, 100)]
    [Required]
    [NotifyDataErrorInfo]
    [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
    private int? _movementSpeed;

    public EditTameViewModel(TameService? tameService)
    {
        AvailableTames = tameService?.GetTameInfosFromFile();
    }

    private int GetLevel()
    {
        var result = 1 +
            (_health ?? 0) +
            (_stamina ?? 0) +
            (_oxygen ?? 0) +
            (_food ?? 0) +
            (_weight ?? 0) +
            (_meleeDamage ?? 0) +
            (_movementSpeed ?? 0);

        return result;
    }
    
    [RelayCommand]
    private void SetSex(Sex sex)
    {
        SelectedSex = sex;
    }

    private bool CanSave()
    {
        return !HasErrors;
    }

    [RelayCommand(IncludeCancelCommand = true, CanExecute = nameof(CanSave))]
    private async Task Save(CancellationToken token)
    {
        ValidateAllProperties();
        if (HasErrors)
        {
            return;
        }
        await Task.Delay(6000, token);
    }
}