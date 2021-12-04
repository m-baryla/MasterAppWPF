using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace PluginInterface
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
        //public void LoadView(TabControl tabPlugs)
        //{
        //    try
        //    {
        //        //Configure path of PlugBoard folder to access all calculate libraries 
        //        //string plugName = ConfigurationSettings.AppSettings["Plugs"].ToString();
        //        string plugName = @"D:\SOURCE\_MySource\[PLATFORM] .NET 5.0\[PROJECTS] WPF\_MasterApp\Plugins";
        //        //TabItem buttonA = new TabItem();
        //        //buttonA.Header = "Welcome";
        //        //buttonA.Height = 30;
        //        //buttonA.Content = "You welcome :)";
        //        //tabPlugs.Items.Add(buttonA);

        //        var connectors = Directory.GetDirectories(plugName);
        //        foreach (var connect in connectors)
        //        {
        //            string dllPath = GetPluggerDll(connect);
        //            Assembly _Assembly = Assembly.LoadFile(dllPath);
        //            var types = _Assembly.GetTypes()?.ToList();
        //            var type = types?.Find(a => typeof(IPlugger).IsAssignableFrom(a));
        //            var win = (IPlugger)Activator.CreateInstance(type);
        //            TabItem button = new TabItem
        //            {
        //                Header = win.PluggerName,
        //                Height = 30,
        //                Content = win.GetPlugger()
        //            };
        //            tabPlugs.Items.Add(button);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Internal Error", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }
        //}
        public void LoadView(TabControl tabPlugs,string path)
        {
            try
            {
                //string plugName = @"D:\SOURCE\_MySource\[PLATFORM] .NET 5.0\[PROJECTS] WPF\_MasterApp\Plugins";
                string plugName = path;

                var connectors = Directory.GetDirectories(plugName);
                foreach (var connect in connectors)
                {
                    string dllPath = GetPluggerDll(connect);
                    Assembly _Assembly = Assembly.LoadFile(dllPath);
                    var types = _Assembly.GetTypes()?.ToList();
                    var type = types?.Find(a => typeof(IPlugger).IsAssignableFrom(a));
                    var win = (IPlugger)Activator.CreateInstance(type);
                    TabItem button = new TabItem
                    {
                        Header = win.PluggerName,
                        Height = 30,
                        Content = win.GetPlugger()
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
