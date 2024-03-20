namespace DemoMS.Service.Common.Repository.MongoDBDatabaseRepository.Entities
{
    public class MongoDBContext<T> where T :IEntity
    {
       
        private readonly string _collectionName;
        private readonly string _databaseName;
      
        public IMongoCollection<T> ItemsCollection { get; set; }
      
        public FilterDefinitionBuilder<T> FilterBuilderItem{ get; set; }

        public MongoDBContext(string connectionString,string collectionName,string databaseName)
        {
            var mongoClient = new MongoClient(connectionString);

            _databaseName = databaseName;
            _collectionName = collectionName;
            
            var database = mongoClient.GetDatabase(_databaseName);
            ItemsCollection = database.GetCollection<T>(_collectionName);
            FilterBuilderItem = Builders<T>.Filter;
        }
    }
}
