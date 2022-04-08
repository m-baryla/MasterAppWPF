using System.Configuration;
using System.IO;
using System.Windows;
using Interface;
using ModuleLoader;

namespace MasterApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var sql = ModuleLoaderService.LoadHelperSQL<ISQL>(GetPath("SQLService"), GetSqlConnectionString());
            var availablePluginService = ModuleLoaderService.LoadAvailablePluginService<IAvailablePluginService>(GetPath("ModuleLoader"), sql);
            availablePluginService.Init(tabPlugs);
        }

        private static string GetPath(string key)
        {
            return Directory.GetParent(Directory.GetCurrentDirectory())?.Parent.Parent.Parent.FullName + ConfigurationManager.AppSettings.Get(key);
        }
        private static string GetSqlConnectionString()
        {
            return ConfigurationManager.AppSettings.Get("sqlConnectionString");
        }
    }
}
