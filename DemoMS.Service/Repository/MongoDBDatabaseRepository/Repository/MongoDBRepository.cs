using DemoMS.Service.Catalog.Repository.DatabaseRepository_MongoDB.Entities.Interfaces;
using DemoMS.Service.Repository.DatabaseRepository_MongoDB.Entities;
using DemoMS.Service.Repository.DatabaseRepository_MongoDB.Repository.Interfaces;
using MongoDB.Driver;

namespace DemoMS.Service.Repository.DatabaseRepository_MongoDB.Repository
{
    public class MongoDBRepository<T> : IMongoDBRepository<T> where T : IEntity
    {
        private readonly MongoDBContext<T> _db;

        public MongoDBRepository(MongoDBContext<T> mongoDBContext)
        {
            _db = mongoDBContext;
        }

        public async Task<IReadOnlyCollection<T>> GetAllDataAsync()
        {
            var filter = _db.FilterBuilderItem.Empty;
            return await _db.ItemsCollection.Find(filter).ToListAsync();
        }

        public async Task<T> GetDataByIDAsync(Guid id)
        {
            var filter = _db.FilterBuilderItem.Eq(entity => entity.Id, id);
            return await _db.ItemsCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task AddDataAsync(T item)
        {
            await _db.ItemsCollection.InsertOneAsync(item);
        }

        public async Task UpdateDataAsync(T item,Guid id)
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
