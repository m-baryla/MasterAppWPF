using System.Configuration;
using System.IO;

namespace HelperClass
{
    public static class Config
    {
        public static string GetSqlConnectionString()
        {
            return ConfigurationManager.AppSettings.Get("sqlConnectionString");
        }

        public static string GetDllPath()
        {
            return Directory.GetParent(Directory.GetCurrentDirectory())?.Parent.Parent.Parent.FullName + ConfigurationManager.AppSettings.Get("dllsPath");
        }
    }
}
