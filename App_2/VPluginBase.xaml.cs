using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using App_2.T_1.ViewModel;
using BaseAppClass;
using Interface;

namespace App_2
{
    /// <summary>
    /// Interaction logic for VPluginBase.xaml
    /// </summary>
    public partial class VPluginBase : UserControl, IPlugger
    {
        public VPluginBase()
        {
            var sqlDynamicDLL = ModuleLoaderService.LoadHelperSQL<ISQL>(GetConfigService.GetPath("dllsSQL"), null);
            InitializeComponent();
            DataContext = new VMPluginBase(Resources["ButtonStyle"] as Style, sqlDynamicDLL);
        }
        public string PluggerName { get; set; } = "PluginBaseApp2";
        public UserControl GetPlugger() => this;
    }
}



