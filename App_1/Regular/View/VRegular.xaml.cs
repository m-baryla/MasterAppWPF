using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;
using App_1.Regular.Model;
using App_1.Regular.ViewModel;

namespace App_1.Regular.View
{
    /// <summary>
    /// Interaction logic for VRegular.xaml
    /// </summary>
    public partial class VRegular : UserControl
    {
        public VRegular(VMRegular vmRegular)
        {
            InitializeComponent();
            DataContext = vmRegular;
        }
        private void AllowOnlyNumbers(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

    }
}
