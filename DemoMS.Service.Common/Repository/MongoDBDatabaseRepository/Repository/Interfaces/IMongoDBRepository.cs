namespace DemoMS.Service.Common.Repository.MongoDBDatabaseRepository.Interfaces
{
    public interface IMongoDBRepository<T> where T : IEntity
    {
        Task AddDataAsync(T item);
        Task DeleteDataAsync(Guid id);
        Task<IReadOnlyCollection<T>> GetAllDataAsync();
        Task<IReadOnlyCollection<T>> GetAllDataAsync(Expression <Func<T,bool>> filter);
        Task<T> GetDataByIDAsync(Guid id);
        Task<T> GetDataByIDAsync(Expression<Func<T, bool>> filter);
        Task UpdateDataAsync(T item, Guid id);
    }
}