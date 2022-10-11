using ArkTameClassic.Framework;

namespace ArkTameClassic.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public static MainWindowViewModel Design { get; } = new(null);

    public MainWindowViewModel(EditTameViewModelClassic? editTameViewModel)
    {
        EditView = editTameViewModel;
    }

    public object? EditView { get; }

    public record TameInfo(string Name, string? UrlPath);
}