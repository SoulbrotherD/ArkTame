using System.Collections.Generic;
using System.IO;
using System.Linq;
using HtmlAgilityPack;
using Newtonsoft.Json;

namespace ArkTame.ViewModels;

public class MainWindowViewModel
{

    public static MainWindowViewModel Design { get; } = new(null);

    public MainWindowViewModel(EditTameViewModel? editTameViewModel)
    {
        EditView = editTameViewModel;
    }

    public object? EditView { get; set; } 

    public record TameInfo(string Name, string? UrlPath);
}