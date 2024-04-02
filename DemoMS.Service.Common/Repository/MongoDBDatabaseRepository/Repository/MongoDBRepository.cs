namespace DemoMS.Service.Common.Repository.MongoDBDatabaseRepository.Repository
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
            return await _db.DataCollection.Find(filter).ToListAsync();
        }

        public async Task<IReadOnlyCollection<T>> GetAllDataAsync(Expression<Func<T, bool>> filter)
        {
            return await _db.DataCollection.Find(filter).ToListAsync();
        }

        public async Task<T> GetDataByIDAsync(Guid id)
        {
            var filter = _db.FilterBuilderItem.Eq(entity => entity.Id, id);
            return await _db.DataCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<T> GetDataByIDAsync(Expression<Func<T, bool>> filter)
        {
            return await _db.DataCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task AddDataAsync(T item)
        {
            await _db.DataCollection.InsertOneAsync(item);
        }

        public async Task UpdateDataAsync(T item,Guid id)
        {
            var filter = _db.FilterBuilderItem.Eq(entity => entity.Id, id);
            await _db.DataCollection.ReplaceOneAsync(filter, item);
        }

        public async Task DeleteDataAsync(Guid id)
        {
            var filter = _db.FilterBuilderItem.Eq(entity => entity.Id, id);
            await _db.DataCollection.DeleteOneAsync(filter);
        }
    }
}
