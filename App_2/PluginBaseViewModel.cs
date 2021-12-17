using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using App_2.T_1.ViewModel;
using BaseAppClass;
using Interface;

namespace App_2
{
    public class PluginBaseViewModel : ViewModelBaseService
    {
        private readonly ContentControl _cc;
        private List<Button> buttonsList;
        public List<Button> ButtonsList
        {
            get { return buttonsList; }
            set { if (buttonsList == value) return; buttonsList = value; OnPropertyChanged("ButtonsList"); }
        }
        public PluginBaseViewModel(ContentControl cc, Style ButtonStyle, ISQL sql)
        {
            _cc = cc;
            buttonsList = new List<Button>();
            if (UserPermissions.IsAllowed(ApplicationRoles.T_1, sql))  buttonsList.Add(new Button() { Style = ButtonStyle, Content = "T_1", Command = new RelayCommandService(_ => _RegularCommandLoad(sql)) });
            if (UserPermissions.IsAllowed(ApplicationRoles.T_1, sql))  buttonsList.Add(new Button() { Style = ButtonStyle, Content = "T_1", Command = new RelayCommandService(_ => _RegularCommandLoad(sql)) });
            if (UserPermissions.IsAllowed(ApplicationRoles.T_1, sql))  buttonsList.Add(new Button() { Style = ButtonStyle, Content = "T_1", Command = new RelayCommandService(_ => _TrigonometryCommandLoad(sql)) });
            if (UserPermissions.IsAllowed(ApplicationRoles.T_2, sql))  buttonsList.Add(new Button() { Style = ButtonStyle, Content = "T_2", Command = new RelayCommandService(_ => _RegularCommandLoad(sql)) });
            if (UserPermissions.IsAllowed(ApplicationRoles.T_2, sql))  buttonsList.Add(new Button() { Style = ButtonStyle, Content = "T_2", Command = new RelayCommandService(_ => _TrigonometryCommandLoad(sql)) });
            if (UserPermissions.IsAllowed(ApplicationRoles.T_2, sql))  buttonsList.Add(new Button() { Style = ButtonStyle, Content = "T_2", Command = new RelayCommandService(_ => _RegularCommandLoad(sql)) });
            if (UserPermissions.IsAllowed(ApplicationRoles.T_2, sql))  buttonsList.Add(new Button() { Style = ButtonStyle, Content = "T_2", Command = new RelayCommandService(_ => _TrigonometryCommandLoad(sql)) });
        }
        private void _RegularCommandLoad(ISQL sqlDynamicDLL)
        {
            var aa = new ValueT1ViewModel(sqlDynamicDLL);
            aa.GetValueT1Model_DataTable();

            #region test

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
            //aa.ModValueT1ModelParametersOneRow(5, "MBA");


            //ValueT2ViewModel
            //var bb = new ValueT2ViewModel();

            #endregion
        }

        private void _TrigonometryCommandLoad(ISQL sqlDynamicDLL)
        {
            var aa = new ValueT1ViewModel(sqlDynamicDLL);
            aa.GetValueT1Model_DataTable();
        }
    }
}
