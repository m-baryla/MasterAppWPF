using System;
using System.Configuration;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace BaseClassApp.Helper
{
    public static class GetConfigService
    {
        private static string GetPath(string key)
        {
            return Directory.GetParent(Directory.GetCurrentDirectory())?.Parent.Parent.Parent.FullName + ConfigurationManager.AppSettings.Get(key);
        }

        public static Image GetIcon(string key)
        {
            Image image = new Image();
            image.Source = new BitmapImage(new Uri(GetPath(key)));
            return image;
        }
    }
}
