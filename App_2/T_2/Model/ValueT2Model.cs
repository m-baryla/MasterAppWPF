using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelperClass;

namespace App_2.T_2.Model
{
    public class ValueT2Model : ViewModelBase
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


        public ValueT2Model()
        {

        }
        public ValueT2Model(DataRow row)
        {
            DateTimeValue = string.IsNullOrWhiteSpace(row["DateTimeValue"].ToString()) ? (DateTime?)null : DateTime.Parse(row["DateTimeValue"].ToString());
            DoubleVaule = string.IsNullOrWhiteSpace(row["DoubleVaule"].ToString()) ? (double?)null : double.Parse(row["DoubleVaule"].ToString());
            StringValue = row["StringValue"].ToString();
            IntValue = string.IsNullOrWhiteSpace(row["IntValue"].ToString()) ? (int?)null : int.Parse(row["IntValue"].ToString());
        }
        public ValueT2Model(DataRow row, int IntValue)
        {
            this.IntValue = IntValue;
            DateTimeValue = string.IsNullOrWhiteSpace(row["DateTimeValue"].ToString()) ? (DateTime?)null : DateTime.Parse(row["DateTimeValue"].ToString());
            DoubleVaule = string.IsNullOrWhiteSpace(row["DoubleVaule"].ToString()) ? (double?)null : double.Parse(row["DoubleVaule"].ToString());
            StringValue = row["StringValue"].ToString();
        }
    }
}
