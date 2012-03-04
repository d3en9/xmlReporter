using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using MongoDB.Bson;

namespace xmlStorage
{
    public static class MongoDbHelper
    {
        static Settings settings = MainFactory.GetObject<Settings>();
        static MongoServer _server = null;
        static MongoServer server
        {
            get
            {
                if (_server == null)
                    _server = MongoServer.Create(settings.ConnectionString);
                return _server;
            }
        }

        static MongoDatabase db
        {
            get
            {
                return server.GetDatabase(settings.DatabaseName);
            }
        }

        public static IEnumerable<string> getCollectionNames()
        {
            try
            {
                return db.GetCollectionNames();
            }
            catch
            {
                //todo log
                throw;
            }
        }

    }
}
