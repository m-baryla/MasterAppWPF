using System.Configuration;
using System.IO;

namespace BaseAppClass
{
    public static class GetConfig
    {
        public static string GetPath(string key)
        {
            return Directory.GetParent(Directory.GetCurrentDirectory())?.Parent.Parent.Parent.FullName + ConfigurationManager.AppSettings.Get(key);
        }
        public static string GetSqlConnectionString()
        {
            return ConfigurationManager.AppSettings.Get("sqlConnectionString");
        }
    }
}
