using System.Windows;
using System.Windows.Controls;
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
            InitializeComponent();
            DataContext = new PluginBaseViewModel(CustomContentControl, Resources["ButtonStyle"] as Style);
        }
        public string PluggerName { get; set; } = "PluginBaseApp1";
        public UserControl GetPlugger() => this;

    }
}
