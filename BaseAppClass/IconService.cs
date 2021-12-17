using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace BaseAppClass
{
    public static class IconService
    {
        public static Image SetIcon(string key)
        {
            Image image = new Image();
            image.Source = new BitmapImage(new Uri(GetConfigService.GetPath(key)));
            return image;
        }
    }
}
