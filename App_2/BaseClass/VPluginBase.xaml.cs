﻿using System.Windows;
using System.Windows.Controls;
using BaseClassApp.Interface;

namespace App_2.BaseClass
{
    /// <summary>
    /// Interaction logic for VPluginBase.xaml
    /// </summary>
    public partial class VPluginBase : UserControl,IPlugger
    {
        public VPluginBase(ISQL sql)
        {
            InitializeComponent();
            DataContext = new VMPluginBase(Resources["ButtonStyle"] as Style, sql);
        }
        public string PluginName { get; set; } = "PluginBaseApp2";
        public UserControl PluginControl() => this;
    }
}



