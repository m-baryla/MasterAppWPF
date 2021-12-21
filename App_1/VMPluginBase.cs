using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using App_1.Regular.Model;
using App_1.Regular.View;
using App_1.Regular.ViewModel;
using App_1.Trigonometry.View;
using App_1.Trigonometry.ViewModel;
using BaseAppClass;
using Interface;

namespace App_1
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
            var sql = ModuleLoaderService.LoadHelperSQL<ISQL>(GetConfigService.GetPath("dllsSQL"), null);

            var Trigonometry = UserPermissions.IsAllowed(ApplicationRoles.Trigonometry, sql);
            var Regular = UserPermissions.IsAllowed(ApplicationRoles.Regular, sql);

            buttonsList = new List<Button>();
            if (Trigonometry) buttonsList.Add(new Button() { Style = ButtonStyle, Content = GetConfigService.GetIcon("Trigonometry"), Command = new RelayCommandService(_ => CurrentWorkspace = new VRegular {DataContext = new VMRegular(new MRegular() { x = 9, y = 9, result = 9}) }) });
            if (Regular) buttonsList.Add(new Button() { Style = ButtonStyle, Content = GetConfigService.GetIcon("Regular"), Command = new RelayCommandService(_ => CurrentWorkspace = new VTrigonometry { DataContext = new VMTrigonometry() }) });
        }
    }
}


