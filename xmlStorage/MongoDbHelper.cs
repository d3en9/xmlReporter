using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.IO;

namespace xmlStorage
{
    public static class MongoDbHelper
    {
        static DbSettings settings = MainFactory.GetObject<DbSettings>();
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

        public static void Clear(string collectionName)
        {
            db.GetCollection<BsonDocument>(collectionName).RemoveAll();
        }

        public static void JsonInsert(string collectionName, string Json)
        {
            try
            {
                MongoCollection<BsonDocument> books =
                    db.GetCollection<BsonDocument>(collectionName);
                BsonDocument doc = new BsonDocument();
                object obj = doc.Deserialize(BsonReader.Create(Json), typeof(BsonDocument), 
                    new MongoDB.Bson.Serialization.Options.DocumentSerializationOptions(false));
                books.Insert((BsonDocument)obj);
            }
            catch
            {
                //todo log
                throw;
            }
        }

    }
}
