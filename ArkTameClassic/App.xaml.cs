using System.Windows;
using ArkTameClassic.Framework;
using ArkTameClassic.ViewModels;
using ArkTameClassic.Views;

namespace ArkTameClassic
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly Bootstrapper<MainWindow, MainWindowViewModel> _bs;

        public App()
        {
            _bs = new Bootstrapper<MainWindow, MainWindowViewModel>();
            _bs.Config();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            _bs.Run();
        }
    }
}
