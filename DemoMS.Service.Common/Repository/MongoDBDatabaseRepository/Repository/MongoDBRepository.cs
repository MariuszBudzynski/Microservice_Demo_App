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
            try
            {
                var filter = _db.FilterBuilderItem.Empty;
                return await _db.DataCollection.Find(filter).ToListAsync();
            }
            catch (MongoException ex)
            {
                throw ex;
            }
        }

        public async Task<IReadOnlyCollection<T>> GetAllDataAsync(Expression<Func<T, bool>> filter)
        {
            try
            {
                return await _db.DataCollection.Find(filter).ToListAsync();
            }
            catch (MongoException ex)
            {
                throw ex;
            }
        }

        public async Task<T> GetDataByIDAsync(Guid id)
        {
            try
            {
                var filter = _db.FilterBuilderItem.Eq(entity => entity.Id, id);
                return await _db.DataCollection.Find(filter).FirstOrDefaultAsync();
            }
            catch (MongoException ex)
            {
                throw ex;
            }
        }

        public async Task<T> GetDataByIDAsync(Expression<Func<T, bool>> filter)
        {
            try
            {
                return await _db.DataCollection.Find(filter).FirstOrDefaultAsync();
            }
            catch (MongoException ex)
            {
                throw ex;
            }
        }

        public async Task AddDataAsync(T item)
        {
            try
            {
                await _db.DataCollection.InsertOneAsync(item);
            }
            catch (MongoException ex)
            {
                throw ex;
            }
        }

        public async Task UpdateDataAsync(T item, Guid id)
        {
            try
            {
                var filter = _db.FilterBuilderItem.Eq(entity => entity.Id, id);
                await _db.DataCollection.ReplaceOneAsync(filter, item);
            }
            catch (MongoException ex)
            {
                throw ex;
            }
        }

        public async Task DeleteDataAsync(Guid id)
        {
            try
            {
                var filter = _db.FilterBuilderItem.Eq(entity => entity.Id, id);
                await _db.DataCollection.DeleteOneAsync(filter);
            }
            catch (MongoException ex)
            {
                throw ex;
            }
        }
    }
}
