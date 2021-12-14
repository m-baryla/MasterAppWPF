using System.Configuration;
using System.IO;

namespace HelperClass
{
    public static class GetConfig
    {
        public static string GetDllPath(string key)
        {
            return Directory.GetParent(Directory.GetCurrentDirectory())?.Parent.Parent.Parent.FullName + ConfigurationManager.AppSettings.Get(key);
        }
        public static string GetSqlConnectionString()
        {
            return ConfigurationManager.AppSettings.Get("sqlConnectionString");
        }
    }
}
