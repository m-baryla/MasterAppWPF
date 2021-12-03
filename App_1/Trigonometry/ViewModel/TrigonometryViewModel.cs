using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Helper;

namespace App_1.Trigonometry.ViewModel
{
    public class TrigonometryViewModel : VMBase
    {
        private double x;
        public double X
        {
            get { return x; }
            set { if (x == value) return; x = value; RaisePropertyChanged("X"); }
        }
       
        private double result;
        public double Result
        {
            get { return result; }
            set { if (result == value) return; result = value; RaisePropertyChanged("Result"); }
        }
        public ICommand Sinof { get; set; }
        public ICommand CosOf { get; set; }
        public ICommand TanOf { get; set; }

        public TrigonometryViewModel()
        {
            Sinof = new RelayCommand(_=>_Sinof());
            CosOf = new RelayCommand(_ => _CosOf());
            TanOf = new RelayCommand(_ => _TanOf());
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
