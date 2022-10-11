using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ArkTame.Framework;
using ArkTame.ViewModels;
using ArkTame.Views;

namespace ArkTame
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
