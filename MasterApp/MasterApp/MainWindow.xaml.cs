using System.Windows;
using HelperClass;
using PluginInterface;

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
            AvailablePlugin availablePlugin = new AvailablePlugin();
            availablePlugin.LoadView(tabPlugs,Config.GetDllPath());
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
