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
    public class PluginBaseViewModel : ViewModelBaseService
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
        public PluginBaseViewModel(Style ButtonStyle,ISQL sql)
        {
            buttonsList = new List<Button>();

            if (UserPermissions.IsAllowed(ApplicationRoles.Trigonometry, sql)) buttonsList.Add(new Button() { Style = ButtonStyle, Content = IconService.SetIcon("Trigonometry"), Command = new RelayCommandService(_ => CurrentWorkspace = new RegularView(new RegularViewModel(new RegularModel() { x = 9, y = 9, result = 9 }))) });
            if (UserPermissions.IsAllowed(ApplicationRoles.Regular, sql)) buttonsList.Add(new Button() { Style = ButtonStyle, Content = IconService.SetIcon("Regular"), Command = new RelayCommandService(_ => CurrentWorkspace = new TrigonometryView(new TrigonometryViewModel())) });
        }
    }
}


