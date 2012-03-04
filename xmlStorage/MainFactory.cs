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
            if (typeof(T)== typeof(Settings))
            {
                obj = (T)Activator.CreateInstance(typeof(Settings));
                (obj as Settings).ConnectionString = "mongodb://localhost";
                (obj as Settings).DatabaseName = "xmlStorage";
            }
            return obj;
        }
    }
}
