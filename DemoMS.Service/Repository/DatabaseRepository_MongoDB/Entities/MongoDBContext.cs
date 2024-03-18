using MongoDB.Driver;

namespace DemoMS.Service.Repository.DatabaseRepository_MongoDB.Entities
{
    public class MongoDBContext
    {
        //collection represents a group of objects in MongoDB
        //as in relational database it would be a table
        private const string collectionName = "items";

        //represents the actual MongoDb collection
        public IMongoCollection<Item> ItemsCollection { get; set; }
        //allows to create filters that can be used to search for documents in the MongoDB database.
        public FilterDefinitionBuilder<Item> FilterBuilderItem{ get; set; }

        public MongoDBContext()
        {
            //Used to connect to the MongoDB server
            var connectionString = "mongodb+srv://<cluster-address>/<database-name>?retryWrites=true&w=majority&ssl=true&sslCAFile=<path-to-certificate>"; // replace data to properly connect to configured Mongo DB
            var mongoClient = new MongoClient(connectionString);
            //used to access collections in a database,
            //as well as perform operations such as searching,
            //inserting, updating, and deleting documents.
            var database = mongoClient.GetDatabase("Catalog");
            ItemsCollection = database.GetCollection<Item>(collectionName);
            FilterBuilderItem = Builders<Item>.Filter;
        }
    }
}
