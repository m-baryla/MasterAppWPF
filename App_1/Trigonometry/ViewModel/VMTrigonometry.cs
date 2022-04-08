using System;
using System.Windows;
using System.Windows.Input;
using App_1.BaseClass;
using Interface;

namespace App_1.Trigonometry.ViewModel
{
    public class VMTrigonometry : ViewModelBaseService
    {
        private double x;
        public double X
        {
            get { return x; }
            set { if (x == value) return; x = value; OnPropertyChanged("X"); }
        }
       
        private double result;
        public double Result
        {
            get { return result; }
            set { if (result == value) return; result = value; OnPropertyChanged("Result"); }
        }
        public ICommand SinofCommand { get; set; }
        public ICommand CosOfCommand { get; set; }
        public ICommand TanOfCommand { get; set; }

        public VMTrigonometry()
        {
            SinofCommand = new RelayCommandService(_=>_Sinof());
            CosOfCommand = new RelayCommandService(_ => _CosOf());
            TanOfCommand = new RelayCommandService(_ => _TanOf());
        }
        private void _Sinof()
        {
            Result = Math.Sin(X);
            MessageBox.Show(Result.ToString());
        }

        private void _CosOf()
        {
            Result = Math.Cos(X);
            MessageBox.Show(Result.ToString());
        }

        private void _TanOf()
        {
            Result = Math.Tan(X);
            MessageBox.Show(Result.ToString());
        }
    }
}
