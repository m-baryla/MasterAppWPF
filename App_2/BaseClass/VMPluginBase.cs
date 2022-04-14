using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using App_2.T_1.View;
using App_2.T_1.ViewModel;
using App_2.T_2.View;
using App_2.T_2.ViewModel;
using Interface;

namespace App_2.BaseClass
{
    public class VMPluginBase : ViewModelBaseService
    {
        public VMPluginBase(Style ButtonStyle, ISQL sql)
        {
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
