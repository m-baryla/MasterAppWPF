using System.Configuration;
using System.IO;
using System.Windows;
using BaseAppClass;
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
            var sql = ModuleLoaderService.LoadHelperSQL<ISQL>(GetConfigService.GetPath("SQLService"), GetConfigService.GetSqlConnectionString());
            var availablePluginService = ModuleLoaderService.LoadAvailablePluginService<IAvailablePluginService>(GetConfigService.GetPath("ModuleLoader"), sql);
            availablePluginService.Init(tabPlugs);
        }
    }
}
