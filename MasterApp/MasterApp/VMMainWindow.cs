using System.Collections.ObjectModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BaseClassApp;
using BaseClassApp.Interface;
using BaseClassApp.LogService;
using ModuleLoader;

namespace MasterApp
{
    public class VMMainWindow: ViewModelBaseService
    {
        public ICommand AboutCommand { get; set; }

        public VMMainWindow(TabControl tabPlugs)
        {
            var sql = ModuleLoaderService.LoadHelperSQL<ISQL>(GetPath("SQLService"), GetSqlConnectionString());
            var availablePluginService = ModuleLoaderService.LoadAvailablePluginService<IAvailablePluginService>(GetPath("ModuleLoader"), sql);
            availablePluginService.Init(tabPlugs);
            ExampleMessages = new ObservableCollection<LogMessage>();
            ExampleMessages.CollectionChanged += LogMessages_CollectionChanged;
            Top4LogMessages = ExampleMessages.Reverse().Take(3).ToArray();
            AboutCommand = new RelayCommandService(_ => About());

        }
        private static string GetPath(string key)
        {
            return Directory.GetParent(Directory.GetCurrentDirectory())?.Parent.Parent.Parent.FullName + ConfigurationManager.AppSettings.Get(key);
        }
        private static string GetSqlConnectionString()
        {
            return ConfigurationManager.AppSettings.Get("sqlConnectionString");
        }
        private void About()
        {
            var assemblyName = Assembly.GetEntryAssembly().GetName();
            MessageBox.Show("You are currently running version " + assemblyName.Version + " of " + assemblyName.Name, "About " + assemblyName.Name, MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
