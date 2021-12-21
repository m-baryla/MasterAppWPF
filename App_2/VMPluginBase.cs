using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using App_2.T_1.View;
using App_2.T_1.ViewModel;
using App_2.T_2.View;
using App_2.T_2.ViewModel;
using BaseAppClass;
using Interface;

namespace App_2
{
    public class VMPluginBase : ViewModelBaseService
    {
        private object _currentWorkspace;
        public object CurrentWorkspace
        {
            get { return this._currentWorkspace; }
            set { this._currentWorkspace = value; OnPropertyChanged("CurrentWorkspace"); }
        }
        private List<Button> buttonsList;
        public List<Button> ButtonsList
        {
            get { return buttonsList; }
            set { if (buttonsList == value) return; buttonsList = value; OnPropertyChanged("ButtonsList"); }
        }
        public VMPluginBase(Style ButtonStyle)
        {
            var sql = ModuleLoaderService.LoadHelperSQL<ISQL>(GetConfigService.GetPath("dllsSQL"), GetConfigService.GetSqlConnectionString());

            var T_1 = UserPermissions.IsAllowed(ApplicationRoles.T_1, sql);
            var T_2 = UserPermissions.IsAllowed(ApplicationRoles.T_2, sql);

            buttonsList = new List<Button>();
            if (T_1) buttonsList.Add(new Button() { Style = ButtonStyle, Content = "T_1", Command = new RelayCommandService(_ => CurrentWorkspace = new VT_1 { DataContext = new VMValueT1(sql) }) });
            if (T_1) buttonsList.Add(new Button() { Style = ButtonStyle, Content = "T_1", Command = new RelayCommandService(_ => CurrentWorkspace = new VT_1 { DataContext = new VMValueT1(sql) }) });
            if (T_1) buttonsList.Add(new Button() { Style = ButtonStyle, Content = "T_1", Command = new RelayCommandService(_ => CurrentWorkspace = new VT_1 { DataContext = new VMValueT1(sql) }) });
            if (T_2) buttonsList.Add(new Button() { Style = ButtonStyle, Content = "T_2", Command = new RelayCommandService(_ => CurrentWorkspace = new VT_2 { DataContext = new VMValueT2(sql) }) });
            if (T_2) buttonsList.Add(new Button() { Style = ButtonStyle, Content = "T_2", Command = new RelayCommandService(_ => CurrentWorkspace = new VT_2 { DataContext = new VMValueT2(sql) }) });
            if (T_2) buttonsList.Add(new Button() { Style = ButtonStyle, Content = "T_2", Command = new RelayCommandService(_ => CurrentWorkspace = new VT_2 { DataContext = new VMValueT2(sql) }) });
            if (T_2) buttonsList.Add(new Button() { Style = ButtonStyle, Content = "T_2", Command = new RelayCommandService(_ => CurrentWorkspace = new VT_2 { DataContext = new VMValueT2(sql) }) });
        }
    }
}
