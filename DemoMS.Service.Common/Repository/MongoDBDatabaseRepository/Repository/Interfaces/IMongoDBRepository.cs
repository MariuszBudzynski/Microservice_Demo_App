namespace DemoMS.Service.Common.Repository.MongoDBDatabaseRepository.Interfaces
{
    public interface IMongoDBRepository<T> where T : IEntity
    {
        Task AddDataAsync(T item);
        Task DeleteDataAsync(Guid id);
        Task<IReadOnlyCollection<T>> GetAllDataAsync();
        Task<T> GetDataByIDAsync(Guid id);
        Task UpdateDataAsync(T item, Guid id);
    }
}