using System.Windows.Controls;

namespace App_1
{
    /// <summary>
    /// Interaction logic for PluginBaseView.xaml
    /// </summary>
    public partial class PluginBaseView : UserControl,PluginInterface.IPlugger
    {
        public PluginBaseView()
        {
            InitializeComponent();
            DataContext = new PluginBaseViewModel(CustomContentControl);
        }
        public string PluggerName { get; set; } = "PluginBaseApp1";
        public UserControl GetPlugger() => this;
    }
}
