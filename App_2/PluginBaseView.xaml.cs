using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using App_2.T_1.Model;
using App_2.T_1.ViewModel;
using PluginInterface;

namespace App_2
{
    /// <summary>
    /// Interaction logic for PluginBaseView.xaml
    /// </summary>
    public partial class PluginBaseView : UserControl, IPlugger
    {
        public PluginBaseView()
        {
            InitializeComponent();
            DataContext = new PluginBaseViewModel(CustomContentControl);


            var aa = new ValueT1ViewModel();

            //aa.GetValueT1Model_DataTable();
            //
            //aa.GetValueT1Model_DataTable_WithParametr(1);
            //
            //aa.GetValueT1Model_DataTable_SingleRow("MBA");
            //
            //aa.GetValueT1ModelLabel();
            //
            //ValueT1Model valueT1Model = new ValueT1Model();
            //valueT1Model.IntValue = 1;
            //valueT1Model.DateTimeValue = DateTime.Parse("2021-11-01 00:00:00.000");
            //aa.ModValueT1Model("MBA", valueT1Model);
            //
            //ValueT1Model valueT1Model = new ValueT1Model();
            //valueT1Model.StringValue = "MBA";
            //aa.ModDeleteValueT1Model(1, valueT1Model);
            //
            //aa.GetValueT1ModelWithParametr(3);
            //
            //aa.GetValueT1ModelLabel_v2();
            //
           // ValueT1Model valueT1Model = new ValueT1Model();
           // valueT1Model.DateTimeValue = DateTime.Parse("2021-11-01 00:00:00.000");
           // valueT1Model.DoubleVaule = 0.1;
           // aa.ModValueT1ModelWithOutParametr("TEST", valueT1Model);
            //
            //aa.GetValueT1Model_Dictionary();
            //
            //ValueT1Model valueT1Model = new ValueT1Model();
            //valueT1Model.DoubleVaule = 0.1;
            //valueT1Model.StringValue = "MBA";
            //List<ValueT1Model> qtys = new List<ValueT1Model>();
            //qtys.Add(valueT1Model);
            //ValueT1Model valueT1Model_date = new ValueT1Model();
            //valueT1Model_date.DateTimeValue = DateTime.Parse("2026-11-11 00:00:00.000");
            //List<ValueT1Model> cvs;
            //aa.ModValueT1ModelAddTable(valueT1Model_date, qtys, out cvs);
            //
            //aa.ModValueT1ModelParameters("eeee", DateTime.Parse("2026-11-11 00:00:00.000"), 2);
            //
            //aa.GetValueT1Model_OneRow(10);
            //
            aa.ModValueT1ModelParametersOneRow(5, "MBA");
        }
        public string PluggerName { get; set; } = "PluginBaseApp2";
        public UserControl GetPlugger() => this;
    }
}
