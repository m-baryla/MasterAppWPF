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

namespace App_1
{
    public class PluginBaseViewModel : ViewModelBase
    {
        private readonly ContentControl _cc;
        private List<Button> buttonsList;
        public List<Button> ButtonsList
        {
            get { return buttonsList; }
            set { if (buttonsList == value) return; buttonsList = value; OnPropertyChanged("ButtonsList"); }
        }
        public PluginBaseViewModel(ContentControl cc, Style ButtonStyle)
        {
            _cc = cc;
            buttonsList = new List<Button>();
            buttonsList.Add(new Button() { Style = ButtonStyle, Content = "Regular", Command = new RelayCommand(_ => _RegularCommandLoad()) });
            buttonsList.Add(new Button() { Style = ButtonStyle, Content = "Trigonometry", Command = new RelayCommand(_ => _TrigonometryCommandLoad()) });
        }

        private void _RegularCommandLoad()
        {
            var userControls = new RegularView();
            _cc.Content = userControls.Content;
            _cc.DataContext = new RegularViewModel(new RegularModel() { x = 9, y = 9, result = 9 });
        }

        private void _TrigonometryCommandLoad()
        {
            var userControls = new TrigonometryView();
            _cc.Content = userControls.Content;
            _cc.DataContext = new TrigonometryViewModel();
        }
    }
}


