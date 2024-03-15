using DemoMS.Service.Repository.DatabaseRepository_MongoDB.Entities;
using MongoDB.Driver;

namespace DemoMS.Service.Repository.DatabaseRepository_MongoDB.Repository
{
    public class MongoDBRepository
    {
        private readonly MongoDBContext _db;
       

        public MongoDBRepository(MongoDBContext mongoDBContext)
        {
            _db = mongoDBContext;
        }

        public async Task<IReadOnlyCollection<Item>> GetAllDataAsync()
        {
            var filter = _db.FilterBuilderItem.Empty;
            var items = await _db.ItemsCollection.Find(filter).ToListAsync();
            return items;
        }

        public async Task<Item> GetDataByIDAsync(Guid id)
        {
            var filter = _db.FilterBuilderItem.Eq(entity =>entity.Id,id);
            return await _db.ItemsCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task AddDataAsync(Item item)
        {

        }
    }
}
