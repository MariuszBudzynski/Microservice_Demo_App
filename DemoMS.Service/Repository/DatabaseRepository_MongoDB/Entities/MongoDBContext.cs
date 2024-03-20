using DemoMS.Service.Catalog.Repository.DatabaseRepository_MongoDB.Entities.Interfaces;
using MongoDB.Driver;

namespace DemoMS.Service.Repository.DatabaseRepository_MongoDB.Entities
{
    public class MongoDBContext<T> where T :IEntity
    {
        //collection represents a group of objects in MongoDB
        //as in relational database it would be a table
        private readonly string _collectionName;
        private readonly string _databaseName;
        //represents the actual MongoDb collection
        public IMongoCollection<T> ItemsCollection { get; set; }
        //allows to create filters that can be used to search for documents in the MongoDB database.
        public FilterDefinitionBuilder<T> FilterBuilderItem{ get; set; }

        public MongoDBContext(string connectionString,string collectionName,string databaseName)
        {
            //Used to connect to the MongoDB server
            var mongoClient = new MongoClient(connectionString);
            //used to access collections in a database,
            //as well as perform operations such as searching,
            //inserting, updating, and deleting documents.

            _databaseName = databaseName;
            _collectionName = collectionName;
            
            var database = mongoClient.GetDatabase(_databaseName);
            ItemsCollection = database.GetCollection<T>(_collectionName);
            FilterBuilderItem = Builders<T>.Filter;
        }
    }
}
