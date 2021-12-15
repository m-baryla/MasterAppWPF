using System.Windows.Controls;

namespace Interface
{
    public interface IPlugger
    {
        string PluggerName { get; set; }
        UserControl GetPlugger();
    }
}
