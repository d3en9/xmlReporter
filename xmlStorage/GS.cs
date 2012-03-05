using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;

namespace xmlStorage
{
    /// <summary>
    /// Global Singlton
    /// </summary>
    public class GS
    {
        private static GS instance;
        public IMainFactory mainFactory = new MainFactory();
        
        private GS() { }

        public static GS Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GS();
                }
                return instance;
            }
        }
    }
}
