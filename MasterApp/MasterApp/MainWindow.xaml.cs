using System.Configuration;
using System.IO;
using System.Windows;
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
            HelperClass.InitPlugins.Init(tabPlugs);
        }
    }
}
