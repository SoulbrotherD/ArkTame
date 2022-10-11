using System.Windows;
using ArkTame.Services;
using ArkTame.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ArkTame.Framework;

public class Bootstrapper<TMainWindow, TMainWindowViewModel>
    where TMainWindow : Window
    where TMainWindowViewModel : class
{
    private IHost? _host = null;

    
    public void Config()
    {
        var builder = Host.CreateDefaultBuilder();

        builder.ConfigureAppConfiguration(SetUpConfiguration);
        builder.ConfigureServices(SetUpServices);
        _host = builder.Build();
    }

    private void SetUpServices(HostBuilderContext context, IServiceCollection collection)
    {
        collection.AddSingleton<TMainWindow>();
        collection.AddSingleton<TMainWindowViewModel>();
        collection.AddSingleton<TameService>();
        collection.AddTransient<EditTameViewModel>();
    }

    private void SetUpConfiguration(HostBuilderContext context, IConfigurationBuilder builder)
    {

    }

    public void Run()
    {
        if (_host == null)
        {
            Config();
        }

        var services = _host!.Services;
        var window = services.GetRequiredService<TMainWindow>();
        window.DataContext = services.GetRequiredService<TMainWindowViewModel>();
        window.Show();
    }
}