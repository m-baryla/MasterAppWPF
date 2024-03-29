﻿using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using App_1.Regular.Model;
using App_1.Regular.View;
using App_1.Regular.ViewModel;
using App_1.Trigonometry.View;
using App_1.Trigonometry.ViewModel;
using BaseClassApp;
using BaseClassApp.Helper;
using BaseClassApp.Interface;

namespace App_1.BaseClass
{
    public class VMPluginBase : ViewModelBaseService
    {
        public VMPluginBase(Style ButtonStyle, ISQL sql)
        {
            var Trigonometry = UserPermissions.IsAllowed(ApplicationRoles.Regular, sql);
            var Regular = UserPermissions.IsAllowed(ApplicationRoles.Trigonometry, sql);

            buttonsList = new List<Button>();
            if (Trigonometry) buttonsList.Add(new Button() { Style = ButtonStyle, Content = GetConfigService.GetIcon("Trigonometry"), Command = new RelayCommandService(_ => CurrentWorkspace = new VRegular {DataContext = new VMRegular(new MRegular() { x = 9, y = 9, result = 9}) }) });
            if (Regular) buttonsList.Add(new Button() { Style = ButtonStyle, Content = GetConfigService.GetIcon("Regular"), Command = new RelayCommandService(_ => CurrentWorkspace = new VTrigonometry { DataContext = new VMTrigonometry() }) });
            if (Trigonometry) buttonsList.Add(new Button() { Style = ButtonStyle, Content = GetConfigService.GetIcon("Trigonometry"), Command = new RelayCommandService(_ => CurrentWorkspace = new VRegular { DataContext = new VMRegular(new MRegular() { x = 9, y = 9, result = 9 }) }) });
            if (Regular) buttonsList.Add(new Button() { Style = ButtonStyle, Content = GetConfigService.GetIcon("Regular"), Command = new RelayCommandService(_ => CurrentWorkspace = new VTrigonometry { DataContext = new VMTrigonometry() }) });
            if (Trigonometry) buttonsList.Add(new Button() { Style = ButtonStyle, Content = GetConfigService.GetIcon("Trigonometry"), Command = new RelayCommandService(_ => CurrentWorkspace = new VRegular { DataContext = new VMRegular(new MRegular() { x = 9, y = 9, result = 9 }) }) });
            if (Regular) buttonsList.Add(new Button() { Style = ButtonStyle, Content = GetConfigService.GetIcon("Regular"), Command = new RelayCommandService(_ => CurrentWorkspace = new VTrigonometry { DataContext = new VMTrigonometry() }) });
            if (Trigonometry) buttonsList.Add(new Button() { Style = ButtonStyle, Content = GetConfigService.GetIcon("Trigonometry"), Command = new RelayCommandService(_ => CurrentWorkspace = new VRegular { DataContext = new VMRegular(new MRegular() { x = 9, y = 9, result = 9 }) }) });
            if (Regular) buttonsList.Add(new Button() { Style = ButtonStyle, Content = GetConfigService.GetIcon("Regular"), Command = new RelayCommandService(_ => CurrentWorkspace = new VTrigonometry { DataContext = new VMTrigonometry() }) });
            if (Trigonometry) buttonsList.Add(new Button() { Style = ButtonStyle, Content = GetConfigService.GetIcon("Trigonometry"), Command = new RelayCommandService(_ => CurrentWorkspace = new VRegular { DataContext = new VMRegular(new MRegular() { x = 9, y = 9, result = 9 }) }) });
            if (Regular) buttonsList.Add(new Button() { Style = ButtonStyle, Content = GetConfigService.GetIcon("Regular"), Command = new RelayCommandService(_ => CurrentWorkspace = new VTrigonometry { DataContext = new VMTrigonometry() }) });
            if (Trigonometry) buttonsList.Add(new Button() { Style = ButtonStyle, Content = GetConfigService.GetIcon("Trigonometry"), Command = new RelayCommandService(_ => CurrentWorkspace = new VRegular { DataContext = new VMRegular(new MRegular() { x = 9, y = 9, result = 9 }) }) });
            if (Regular) buttonsList.Add(new Button() { Style = ButtonStyle, Content = GetConfigService.GetIcon("Regular"), Command = new RelayCommandService(_ => CurrentWorkspace = new VTrigonometry { DataContext = new VMTrigonometry() }) });
            if (Trigonometry) buttonsList.Add(new Button() { Style = ButtonStyle, Content = GetConfigService.GetIcon("Trigonometry"), Command = new RelayCommandService(_ => CurrentWorkspace = new VRegular { DataContext = new VMRegular(new MRegular() { x = 9, y = 9, result = 9 }) }) });
            if (Regular) buttonsList.Add(new Button() { Style = ButtonStyle, Content = GetConfigService.GetIcon("Regular"), Command = new RelayCommandService(_ => CurrentWorkspace = new VTrigonometry { DataContext = new VMTrigonometry() }) });
            if (Trigonometry) buttonsList.Add(new Button() { Style = ButtonStyle, Content = GetConfigService.GetIcon("Trigonometry"), Command = new RelayCommandService(_ => CurrentWorkspace = new VRegular { DataContext = new VMRegular(new MRegular() { x = 9, y = 9, result = 9 }) }) });
            if (Regular) buttonsList.Add(new Button() { Style = ButtonStyle, Content = GetConfigService.GetIcon("Regular"), Command = new RelayCommandService(_ => CurrentWorkspace = new VTrigonometry { DataContext = new VMTrigonometry() }) });
            if (Trigonometry) buttonsList.Add(new Button() { Style = ButtonStyle, Content = GetConfigService.GetIcon("Trigonometry"), Command = new RelayCommandService(_ => CurrentWorkspace = new VRegular { DataContext = new VMRegular(new MRegular() { x = 9, y = 9, result = 9 }) }) });
            if (Regular) buttonsList.Add(new Button() { Style = ButtonStyle, Content = GetConfigService.GetIcon("Regular"), Command = new RelayCommandService(_ => CurrentWorkspace = new VTrigonometry { DataContext = new VMTrigonometry() }) });
            if (Trigonometry) buttonsList.Add(new Button() { Style = ButtonStyle, Content = GetConfigService.GetIcon("Trigonometry"), Command = new RelayCommandService(_ => CurrentWorkspace = new VRegular { DataContext = new VMRegular(new MRegular() { x = 9, y = 9, result = 9 }) }) });
            if (Regular) buttonsList.Add(new Button() { Style = ButtonStyle, Content = GetConfigService.GetIcon("Regular"), Command = new RelayCommandService(_ => CurrentWorkspace = new VTrigonometry { DataContext = new VMTrigonometry() }) });
            if (Trigonometry) buttonsList.Add(new Button() { Style = ButtonStyle, Content = GetConfigService.GetIcon("Trigonometry"), Command = new RelayCommandService(_ => CurrentWorkspace = new VRegular { DataContext = new VMRegular(new MRegular() { x = 9, y = 9, result = 9 }) }) });
            if (Regular) buttonsList.Add(new Button() { Style = ButtonStyle, Content = GetConfigService.GetIcon("Regular"), Command = new RelayCommandService(_ => CurrentWorkspace = new VTrigonometry { DataContext = new VMTrigonometry() }) });
            if (Trigonometry) buttonsList.Add(new Button() { Style = ButtonStyle, Content = GetConfigService.GetIcon("Trigonometry"), Command = new RelayCommandService(_ => CurrentWorkspace = new VRegular { DataContext = new VMRegular(new MRegular() { x = 9, y = 9, result = 9 }) }) });
            if (Regular) buttonsList.Add(new Button() { Style = ButtonStyle, Content = GetConfigService.GetIcon("Regular"), Command = new RelayCommandService(_ => CurrentWorkspace = new VTrigonometry { DataContext = new VMTrigonometry() }) });
            if (Trigonometry) buttonsList.Add(new Button() { Style = ButtonStyle, Content = GetConfigService.GetIcon("Trigonometry"), Command = new RelayCommandService(_ => CurrentWorkspace = new VRegular { DataContext = new VMRegular(new MRegular() { x = 9, y = 9, result = 9 }) }) });
            if (Regular) buttonsList.Add(new Button() { Style = ButtonStyle, Content = GetConfigService.GetIcon("Regular"), Command = new RelayCommandService(_ => CurrentWorkspace = new VTrigonometry { DataContext = new VMTrigonometry() }) });
            if (Trigonometry) buttonsList.Add(new Button() { Style = ButtonStyle, Content = GetConfigService.GetIcon("Trigonometry"), Command = new RelayCommandService(_ => CurrentWorkspace = new VRegular { DataContext = new VMRegular(new MRegular() { x = 9, y = 9, result = 9 }) }) });
            if (Regular) buttonsList.Add(new Button() { Style = ButtonStyle, Content = GetConfigService.GetIcon("Regular"), Command = new RelayCommandService(_ => CurrentWorkspace = new VTrigonometry { DataContext = new VMTrigonometry() }) });
            if (Trigonometry) buttonsList.Add(new Button() { Style = ButtonStyle, Content = GetConfigService.GetIcon("Trigonometry"), Command = new RelayCommandService(_ => CurrentWorkspace = new VRegular { DataContext = new VMRegular(new MRegular() { x = 9, y = 9, result = 9 }) }) });
            if (Regular) buttonsList.Add(new Button() { Style = ButtonStyle, Content = GetConfigService.GetIcon("Regular"), Command = new RelayCommandService(_ => CurrentWorkspace = new VTrigonometry { DataContext = new VMTrigonometry() }) });
        }
    }
}


