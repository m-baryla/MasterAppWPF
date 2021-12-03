using System.Windows;
using System.Windows.Input;
using Helper;

namespace App_1.Regular.ViewModel
{
    public class RegularViewModel : VMBase
    {
        private float x;
        public float X
        {
            get { return x; }
            set { if (x == value) return; x = value; RaisePropertyChanged("X"); }
        }
        private float y;
        public float Y
        {
            get { return y; }
            set { if (y == value) return; y = value; RaisePropertyChanged("Y"); }
        }
        private float result;
        public float Result
        {
            get { return result; }
            set { if (result == value) return; result = value; RaisePropertyChanged("Result"); }
        }

        public ICommand Add { get; set; }
        public ICommand Substract { get; set; }
        public ICommand Multiply { get; set; }
        public ICommand Divide { get; set; }

        public RegularViewModel()
        {
            Add = new RelayCommand(_ => _Add());
            Substract = new RelayCommand(_ => _Substract());
            Multiply = new RelayCommand(_ => _Multiply());
            Divide = new RelayCommand(_ => _Divide());
        }

        private void _Add()
        {
            Result = X + Y;
            MessageBox.Show(Result.ToString());
        }

        private void _Substract()
        {
            Result = X - Y;
            MessageBox.Show(Result.ToString());
        }

        private void _Multiply()
        {
            Result = X * Y;   
            MessageBox.Show(Result.ToString());
        }

        private void _Divide()
        {
            Result = X / Y;
            MessageBox.Show(Result.ToString());
        }
    }
}
