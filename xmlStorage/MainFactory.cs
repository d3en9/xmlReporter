using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xmlStorage
{
    public static class MainFactory
    {
        public static T GetObject<T>()
        {
            T obj = default(T);
            if (typeof(T)== typeof(DbSettings))
            {
                obj = (T)Activator.CreateInstance(typeof(DbSettings));
                (obj as DbSettings).ConnectionString = "mongodb://localhost";
                (obj as DbSettings).DatabaseName = "xmlStorage";
            }
            return obj;
        }
    }
}
