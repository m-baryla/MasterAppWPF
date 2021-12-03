using System.Windows.Controls;
using System.Windows.Input;
using App_1.Regular.View;
using App_1.Regular.ViewModel;
using App_1.Trigonometry.View;
using App_1.Trigonometry.ViewModel;
using Helper;

namespace App_1
{
    public class PluginBaseViewModel : VMBase
    {
        private ContentControl _customContentControl;
        //public ContentControl CustomContentControl
        //{
        //    get { return _customContentControl; }
        //    set { if (_customContentControl == value) return; _customContentControl = value; RaisePropertyChanged("CustomContentControl"); }
        //}
        public ICommand RegularCommand { get; set; }
        public ICommand TrigonometryCommand { get; set; }

        public PluginBaseViewModel(ContentControl cc)
        {
            RegularCommand = new RelayCommand(_=>_RegularCommand());
            TrigonometryCommand = new RelayCommand(_ => _TrigonometryCommand());
            this._customContentControl = cc;
        }
        private void _RegularCommand()
        {
            var userControls = new RegularView();
            _customContentControl.Content = userControls.Content;
            _customContentControl.DataContext = new RegularViewModel();
        }

        private void _TrigonometryCommand()
        {
            var userControls = new TrigonometryView();
            _customContentControl.Content = userControls.Content;
            _customContentControl.DataContext = new TrigonometryViewModel();
        }
    }
}
