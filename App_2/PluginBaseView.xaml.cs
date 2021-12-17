using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using App_2.T_1.ViewModel;
using BaseAppClass;
using Interface;

namespace App_2
{
    /// <summary>
    /// Interaction logic for PluginBaseView.xaml
    /// </summary>
    public partial class PluginBaseView : UserControl, IPlugger
    {
        public PluginBaseView()
        {
            var sqlDynamicDLL = ModuleLoaderService.LoadHelperSQL<ISQL>(GetConfigService.GetPath("dllsSQL"), null);
            InitializeComponent();
            DataContext = new PluginBaseViewModel(CustomContentControl, Resources["ButtonStyle"] as Style, sqlDynamicDLL);
        }
        public string PluggerName { get; set; } = "PluginBaseApp2";
        public UserControl GetPlugger() => this;
    }
}



