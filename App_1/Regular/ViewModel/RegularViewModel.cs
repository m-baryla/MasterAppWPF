using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using App_1.Regular.Model;
using BaseAppClass;

namespace App_1.Regular.ViewModel
{
    public class RegularViewModel : ViewModelBaseService
    {
        private readonly RegularModel _regularModel;
        public float X
        {
            get { return _regularModel.x; }
            set { if (_regularModel.x == value) return; _regularModel.x = value; OnPropertyChanged("X"); }
        }
        public float Y
        {
            get { return _regularModel.y; }
            set { if (_regularModel.y == value) return; _regularModel.y = value; OnPropertyChanged("Y"); }
        }
        public float Result
        {
            get { return _regularModel.result; }
            set { if (_regularModel.result == value) return; _regularModel.result = value; OnPropertyChanged("Result"); }
        }

        public ICommand AddCommand { get; set; }
        public ICommand SubstractCommand { get; set; }
        public ICommand MultiplyCommand { get; set; }
        public ICommand DivideCommand { get; set; }
        
        public RegularViewModel(RegularModel regularModel)
        {
            AddCommand = new RelayCommandService(_ => _Add());
            SubstractCommand = new RelayCommandService(_ => _Substract());
            MultiplyCommand = new RelayCommandService(_ => _Multiply());
            DivideCommand = new RelayCommandService(_ => _Divide());
            this._regularModel = regularModel;
        }

        private void _Add()
        {
            Result = X + Y;
            _ = MessageBox.Show(Result.ToString(CultureInfo.InvariantCulture));
        }

        private void _Substract()
        {
            Result = X - Y;
            _ = MessageBox.Show(Result.ToString(CultureInfo.InvariantCulture));
        }

        private void _Multiply()
        {
            Result = X * Y;   
            MessageBox.Show(Result.ToString(CultureInfo.InvariantCulture));
        }

        private void _Divide()
        {
            Result = X / Y;
            _ = MessageBox.Show(Result.ToString(CultureInfo.InvariantCulture));
        }
    }
}
