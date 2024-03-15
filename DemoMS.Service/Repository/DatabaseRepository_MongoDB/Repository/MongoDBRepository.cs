using DemoMS.Service.Repository.DatabaseRepository_MongoDB.Entities;

namespace DemoMS.Service.Repository.DatabaseRepository_MongoDB.Repository
{
    public class MongoDBRepository
    {
        private readonly MongoDBContext _mongoDBContext;

        public MongoDBRepository(MongoDBContext mongoDBContext)
        {
            _mongoDBContext = mongoDBContext;
        }
    }
}
