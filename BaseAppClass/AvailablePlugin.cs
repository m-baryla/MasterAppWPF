using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using Interface;

namespace BaseAppClass
{
    public class AvailablePlugin
    {
        private string GetPluggerDll(string connect)
        {
            var files = Directory.GetFiles(connect + @"\net5.0-windows", "*.dll");
            foreach (var file in files)
            {
                var productName = FileVersionInfo.GetVersionInfo(file).ProductName;
                if (productName != null && productName.StartsWith("Calci"))
                    return file;
            }
            return string.Empty;
        }
        public void LoadView(TabControl tabPlugs, string path)
        {
            try
            {
                string plugName = path;

                var connectors = Directory.GetDirectories(plugName);
                foreach (var connect in connectors)
                {
                    var pluginDynamicDLL = ModuleLoader.LoadPlugger<IPlugger>(GetPluggerDll(connect), null);

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
    }
}
