using System.Windows.Controls;

namespace BaseAppClass
{
    public static class InitPluginsService
    {
        public static void Init(TabControl tabPlugs)
        {
            AvailablePluginService availablePlugin = new AvailablePluginService();
            availablePlugin.LoadView(tabPlugs, GetConfigService.GetPath("dllsPath"));
        }
    }
}
