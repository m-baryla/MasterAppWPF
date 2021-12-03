using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;
using App_1.Trigonometry.ViewModel;

namespace App_1.Trigonometry.View
{
    /// <summary>
    /// Interaction logic for TrigonometryView.xaml
    /// </summary>
    public partial class TrigonometryView : UserControl
    {
        public TrigonometryView()
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
