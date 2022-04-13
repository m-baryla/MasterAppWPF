using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Interface
{
    public interface IPlugger
    {
        public string PluginName { get; set; }
        UserControl PluginControl();
    }
}