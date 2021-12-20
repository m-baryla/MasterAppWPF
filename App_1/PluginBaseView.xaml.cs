using System.Windows;
using System.Windows.Controls;
using BaseAppClass;
using Interface;

namespace App_1
{
    /// <summary>
    /// Interaction logic for PluginBaseView.xaml
    /// </summary>
    public partial class PluginBaseView : UserControl,IPlugger
    {
        public PluginBaseView()
        {
            var sqlDynamicDLL = ModuleLoaderService.LoadHelperSQL<ISQL>(GetConfigService.GetPath("dllsSQL"), null);
            InitializeComponent();
            DataContext = new PluginBaseViewModel(Resources["ButtonStyle"] as Style, sqlDynamicDLL);
        }
        public string PluggerName { get; set; } = "PluginBaseApp1";
        public UserControl GetPlugger() => this;

    }
}
