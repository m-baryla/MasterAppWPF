using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Interface;

namespace ModuleLoader
{
    public class AvailablePluginService : IAvailablePluginService
    {
        private ISQL sql;  
        public AvailablePluginService(ISQL sql)
        {
            this.sql = sql;
        }
        public void Init(TabControl tabPlugs)
        {
            AvailablePluginService availablePlugin = new AvailablePluginService(sql);
            availablePlugin.LoadView(tabPlugs, GetPath("PluginPath"));
        }
        private string GetPluggerDll(string connect)
        {
            //@"\net5.0-windows"
            var files = Directory.GetFiles(connect, "*.dll");
            foreach (var file in files)
            {
                var productName = FileVersionInfo.GetVersionInfo(file).ProductName;
                if (productName != null && productName.StartsWith("_MBA"))
                    return file;
            }
            return string.Empty;
        }
        private void LoadView(TabControl tabPlugs, string path)
        {
            try
            {
                string plugName = path;

                var connectors = Directory.GetDirectories(plugName);
                foreach (var connect in connectors)
                {
                    var pluginDynamicDLL = ModuleLoaderService.LoadPlugger<IPlugger>(GetPluggerDll(connect), sql);

                    TabItem button = new TabItem
                    {
                        Header = pluginDynamicDLL.PluggerName,
                        Content = pluginDynamicDLL.GetPlugger(),
                    };
                    tabPlugs.Items.Add(button);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Internal Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private static string GetPath(string key)
        {
            return Directory.GetParent(Directory.GetCurrentDirectory())?.Parent.Parent.Parent.FullName + ConfigurationManager.AppSettings.Get(key);
        }
    }
}
