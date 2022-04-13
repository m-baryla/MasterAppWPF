using System.Globalization;
using System.Windows;
using System.Windows.Input;
using App_1.BaseClass;
using App_1.Regular.Model;
using Interface;

namespace App_1.Regular.ViewModel
{
    public class VMRegular : ViewModelBaseService
    {
        private readonly MRegular _mRegular;
        public float X
        {
            get { return _mRegular.x; }
            set { if (_mRegular.x == value) return; _mRegular.x = value; OnPropertyChanged("X"); }
        }
        public float Y
        {
            get { return _mRegular.y; }
            set { if (_mRegular.y == value) return; _mRegular.y = value; OnPropertyChanged("Y"); }
        }
        public float Result
        {
            get { return _mRegular.result; }
            set { if (_mRegular.result == value) return; _mRegular.result = value; OnPropertyChanged("Result"); }
        }

        public ICommand AddCommand { get; set; }
        public ICommand SubstractCommand { get; set; }
        public ICommand MultiplyCommand { get; set; }
        public ICommand DivideCommand { get; set; }
        
        public VMRegular(MRegular mRegular)
        {
            AddCommand = new RelayCommandService(_ => _Add());
            SubstractCommand = new RelayCommandService(_ => _Substract());
            MultiplyCommand = new RelayCommandService(_ => _Multiply());
            DivideCommand = new RelayCommandService(_ => _Divide());
            this._mRegular = mRegular;
        }

        private void _Add()
        {
            Result = X + Y;
            _ = MessageBox.Show(Result.ToString(CultureInfo.InvariantCulture));
            VMPluginBase.ExampleMessages.AddLogMessage("11111 " + 123444, LogMessageType.Normal);

        }

        private void _Substract()
        {
            Result = X - Y;
            _ = MessageBox.Show(Result.ToString(CultureInfo.InvariantCulture));
            VMPluginBase.ExampleMessages.AddLogMessage("22222 " + 123444, LogMessageType.Warning);

        }

        private void _Multiply()
        {
            Result = X * Y;
            VMPluginBase.ExampleMessages.AddLogMessage("333333 " + 123444, LogMessageType.Error);

            MessageBox.Show(Result.ToString(CultureInfo.InvariantCulture));
        }

        private void _Divide()
        {
            Result = X / Y;
            _ = MessageBox.Show(Result.ToString(CultureInfo.InvariantCulture));
            VMPluginBase.ExampleMessages.AddLogMessage("444444 " + 123444, LogMessageType.Normal);

        }
    }
}
