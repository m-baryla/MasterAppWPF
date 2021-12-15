using System.Windows.Controls;

namespace BaseAppClass
{
    public static class InitPlugins
    {
        public static void Init(TabControl tabPlugs)
        {
            AvailablePlugin availablePlugin = new AvailablePlugin();
            availablePlugin.LoadView(tabPlugs, GetConfig.GetDllPath("dllsPath"));
        }
    }
}
