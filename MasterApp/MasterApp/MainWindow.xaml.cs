using System.Collections.ObjectModel;
using System.Configuration;
using System.IO;
using System.Reflection;
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
            DataContext = new VMMainWindow(tabPlugs);
        }
       
    }
}
