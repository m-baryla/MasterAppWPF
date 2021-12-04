using System.Windows.Controls;
using System.Windows.Input;
using App_1.Regular.Model;
using App_1.Regular.View;
using App_1.Regular.ViewModel;
using App_1.Trigonometry.View;
using App_1.Trigonometry.ViewModel;
using HelperClass;

namespace App_1
{
    public class PluginBaseViewModel : ViewModelBase
    {
        private readonly ContentControl _cc;
        public ICommand RegularCommandLoad { get; set; }
        public ICommand TrigonometryCommandLoad { get; set; }

        public PluginBaseViewModel(ContentControl cc)
        {
            RegularCommandLoad = new RelayCommand(_ => _RegularCommandLoad());
            TrigonometryCommandLoad = new RelayCommand(_ => _TrigonometryCommandLoad());
            _cc = cc;
        }
        private void _RegularCommandLoad()
        {
            var userControls = new RegularView();
            _cc.Content = userControls.Content;
            _cc.DataContext = new RegularViewModel(new RegularModel() { x = 9, y = 9, result = 9 });
        }

        private void _TrigonometryCommandLoad()
        {
            var userControls = new TrigonometryView();
            _cc.Content = userControls.Content;
            _cc.DataContext = new TrigonometryViewModel();
        }
    }
}


