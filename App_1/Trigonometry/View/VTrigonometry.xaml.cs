using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;
using App_1.Trigonometry.ViewModel;

namespace App_1.Trigonometry.View
{
    /// <summary>
    /// Interaction logic for VTrigonometry.xaml
    /// </summary>
    public partial class VTrigonometry : UserControl
    {
        public VTrigonometry(VMTrigonometry vmTrigonometry)
        {
            InitializeComponent();
            DataContext = vmTrigonometry;
        }
        private void AllowOnlyNumbers(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
