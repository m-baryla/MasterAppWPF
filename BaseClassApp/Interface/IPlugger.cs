using System.Windows.Controls;

namespace BaseClassApp.Interface
{
    public interface IPlugger
    {
        public string PluginName { get; set; }
        UserControl PluginControl();
    }
}