using System.Windows.Controls;

namespace PluginInterface
{
    public interface IPlugger
    {
        /// <summary>
        /// Name of plugger
        /// </summary>
        string PluggerName { get; set; }

        /// <summary>
        /// It will return UserControl which will display on Main application
        /// </summary>
        /// <returns></returns>
        UserControl GetPlugger();
    }
}
