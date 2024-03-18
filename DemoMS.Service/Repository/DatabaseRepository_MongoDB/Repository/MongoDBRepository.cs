using DemoMS.Service.Repository.DatabaseRepository_MongoDB.Entities;
using DemoMS.Service.Repository.DatabaseRepository_MongoDB.Repository.Interfaces;
using MongoDB.Driver;

namespace DemoMS.Service.Repository.DatabaseRepository_MongoDB.Repository
{
    public class MongoDBRepository : IMongoDBRepository<Item>
    {
        private readonly MongoDBContext _db;

        public MongoDBRepository(MongoDBContext mongoDBContext)
        {
            _db = mongoDBContext;
        }

        public async Task<IReadOnlyCollection<Item>> GetAllDataAsync()
        {
            var filter = _db.FilterBuilderItem.Empty;
            return await _db.ItemsCollection.Find(filter).ToListAsync();
        }

        public async Task<Item> GetDataByIDAsync(Guid id)
        {
            var filter = _db.FilterBuilderItem.Eq(entity => entity.Id, id);
            return await _db.ItemsCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task AddDataAsync(Item item)
        {
            await _db.ItemsCollection.InsertOneAsync(item);
        }

        public async Task UpdateDataAsync(Item item,Guid id)
        {
            var filter = _db.FilterBuilderItem.Eq(entity => entity.Id, id);
            await _db.ItemsCollection.ReplaceOneAsync(filter, item);
        }

        public async Task DeleteDataAsync(Guid id)
        {
            var filter = _db.FilterBuilderItem.Eq(entity => entity.Id, id);
            await _db.ItemsCollection.DeleteOneAsync(filter);
        }
    }
}
