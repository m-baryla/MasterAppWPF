using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using HelperClass;

namespace App_2
{
    public class PluginBaseViewModel : ViewModelBase
    {
        private readonly ContentControl _cc;

        public PluginBaseViewModel(ContentControl cc)
        {
            _cc = cc;
        }
    }
}
