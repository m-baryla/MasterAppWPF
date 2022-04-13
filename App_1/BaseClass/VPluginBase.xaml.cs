using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Interface;

namespace App_1.BaseClass
{
    /// <summary>
    /// Interaction logic for VPluginBase.xaml
    /// </summary>
    public partial class VPluginBase : UserControl,IPlugger
    {
        public VPluginBase(ISQL sql)
        {
            InitializeComponent();
            DataContext = new VMPluginBase(Resources["ButtonStyle"] as Style, sql);
        }
        public string PluginName { get; set; } = "PluginBaseApp1";
        public UserControl PluginControl() => this;
    }
}
