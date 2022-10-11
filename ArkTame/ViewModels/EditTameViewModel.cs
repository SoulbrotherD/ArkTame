using System.Collections.Generic;
using System.Threading.Tasks;
using AdonisUI.Controls;
using ArkTame.Services;

namespace ArkTame.ViewModels;

public class EditTameViewModel
{
    // public bool IsMale => SelectedSex == Sex.Male;

    // public bool IsFemale => SelectedSex == Sex.Female;

    public static EditTameViewModel Design { get; } = new(null);

    public IReadOnlyList<TameInfo>? AvailableTames { get; }

    public int Level => GetLevel();

    public EditTameViewModel(TameService? tameService)
    {
        AvailableTames = tameService?.GetTameInfosFromFile();
    }

    private int GetLevel()
    {
        // var result = 1 +
        //     (Health ?? 0) +
        //     (Stamina ?? 0) +
        //     (Oxygen ?? 0) +
        //     (Food ?? 0) +
        //     (Weight ?? 0) +
        //     (MeleeDamage ?? 0) +
        //     (MovementSpeed ?? 0);
        //
        // return result;

        return 0;
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