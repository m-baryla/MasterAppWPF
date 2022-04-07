using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public interface IModuleLoaderService
    {
        T LoadPlugger<T>(string pathToFile, params object[] args) where T : IPlugger;
        T LoadHelperSQL<T>(string pathToFile, params object[] args) where T : ISQL;
        T LoadAvailablePluginService<T>(string pathToFile, params object[] args) where T : IAvailablePluginService;
    }
}
