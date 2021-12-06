using System;
using System.Data;
using System.Windows.Input;
using HelperClass;

namespace App_2.T_1.Model
{
    public class ValueT1Model : ViewModelBase
    {
        private DateTime? dateTimeValue;
        public DateTime? DateTimeValue
        {
            get { return dateTimeValue; }
            set { if (dateTimeValue == value) return; dateTimeValue = value; OnPropertyChanged("DateTimeValue"); }
        }

        private double? doubleVaule;
        public double? DoubleVaule
        {
            get { return doubleVaule; }
            set { if (doubleVaule == value) return; doubleVaule = value; OnPropertyChanged("DoubleVaule"); }
        }

        private string stringValue;
        public string StringValue
        {
            get { return stringValue; }
            set { if (stringValue == value) return; stringValue = value; OnPropertyChanged("StringValue"); }
        }

        private int? intValue;
        public int? IntValue
        {
            get { return intValue; }
            set { if (intValue == value) return; intValue = value; OnPropertyChanged("IntValue"); }
        }


        public ValueT1Model()
        {
            
        }
        public ValueT1Model(DataRow row)
        {
            DateTimeValue = string.IsNullOrWhiteSpace(row["DateTimeValue"].ToString()) ? (DateTime?)null : DateTime.Parse(row["DateTimeValue"].ToString());
            DoubleVaule = string.IsNullOrWhiteSpace(row["DoubleVaule"].ToString()) ? (double?)null : double.Parse(row["DoubleVaule"].ToString());
            StringValue = row["StringValue"].ToString();
            IntValue = string.IsNullOrWhiteSpace(row["IntValue"].ToString()) ? (int?)null : int.Parse(row["IntValue"].ToString());
        }
        public ValueT1Model(DataRow row,int IntValue)
        {
            this.IntValue = IntValue;
            DateTimeValue = string.IsNullOrWhiteSpace(row["DateTimeValue"].ToString()) ? (DateTime?)null : DateTime.Parse(row["DateTimeValue"].ToString());
            DoubleVaule = string.IsNullOrWhiteSpace(row["DoubleVaule"].ToString()) ? (double?)null : double.Parse(row["DoubleVaule"].ToString());
            StringValue = row["StringValue"].ToString();
        }

    }
}
