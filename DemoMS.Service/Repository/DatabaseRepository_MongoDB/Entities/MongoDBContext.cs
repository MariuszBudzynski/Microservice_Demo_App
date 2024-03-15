using MongoDB.Driver;

namespace DemoMS.Service.Repository.DatabaseRepository_MongoDB.Entities
{
    public class MongoDBContext
    {
        //collection represents a group of objects in MongoDB
        //as in relational database it would be a table
        private const string collectionName = "items";

        //represents the actual MongoDb collection
        private readonly IMongoCollection<Item> dbCollection;
        //allows to create filters that can be used to search for documents in the MongoDB database.
        private readonly FilterDefinitionBuilder<Item> filterBuilder = Builders<Item>.Filter;

        public MongoDBContext()
        {
            //Used to connect to the MongoDB server
            var mongoClient = new MongoClient("mongodb://localhost:7241");
            //used to access collections in a database,
            //as well as perform operations such as searching,
            //inserting, updating, and deleting documents.
            var database = mongoClient.GetDatabase("Catalog");
        }
    }
}
