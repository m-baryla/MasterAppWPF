using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace App_1.Regular.View
{
    /// <summary>
    /// Interaction logic for VRegular.xaml
    /// </summary>
    public partial class VRegular : UserControl
    {
        public VRegular()
        {
            InitializeComponent();
        }
        private void AllowOnlyNumbers(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

    }
}
