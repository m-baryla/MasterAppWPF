using Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace BaseAppClass
{
    public static class ModuleLoaderService
    {
        public static T LoadPlugger<T>(string pathToFile, params object[] args) where T : IPlugger => PrivateLoad<T>(pathToFile, args);
        public static T LoadHelperSQL<T>(string pathToFile, params object[] args) where T : ISQL => PrivateLoad<T>(pathToFile, args);
        private static T PrivateLoad<T>(string pathToFile, object[] args)
        {
            IEnumerable<Type> source = File.Exists(pathToFile) ? ((IEnumerable<Type>)Assembly.Load(File.ReadAllBytes(pathToFile)).GetTypes()).Where<Type>((Func<Type, bool>)(type => typeof(T).IsAssignableFrom(type))) : throw new ArgumentException(pathToFile + " does not exist.");
            return source.Count<Type>() == 1 ? (T)Activator.CreateInstance(source.First<Type>(), args) : throw new ArgumentException("Number of " + typeof(T).Name + " in path is not equal to 1.");
        }
    }
}
