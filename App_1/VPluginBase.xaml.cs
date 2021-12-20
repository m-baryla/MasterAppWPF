﻿using System.Windows;
using System.Windows.Controls;
using BaseAppClass;
using Interface;

namespace App_1
{
    /// <summary>
    /// Interaction logic for VPluginBase.xaml
    /// </summary>
    public partial class VPluginBase : UserControl,IPlugger
    {
        public VPluginBase()
        {
            var sqlDynamicDLL = ModuleLoaderService.LoadHelperSQL<ISQL>(GetConfigService.GetPath("dllsSQL"), null);
            InitializeComponent();
            DataContext = new VMPluginBase(Resources["ButtonStyle"] as Style, sqlDynamicDLL);
        }
        public string PluggerName { get; set; } = "PluginBaseApp1";
        public UserControl GetPlugger() => this;

    }
}