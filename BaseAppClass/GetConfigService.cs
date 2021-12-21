using System;
using System.Configuration;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace BaseAppClass
{
    public static class GetConfigService
    {
        public static string GetPath(string key)
        {
            return Directory.GetParent(Directory.GetCurrentDirectory())?.Parent.Parent.Parent.FullName + ConfigurationManager.AppSettings.Get(key);
        }
        public static string GetSqlConnectionString()
        {
            return ConfigurationManager.AppSettings.Get("sqlConnectionString");
        }
        public static Image GetIcon(string key)
        {
            Image image = new Image();
            image.Source = new BitmapImage(new Uri(GetConfigService.GetPath(key)));
            return image;
        }
    }
}
