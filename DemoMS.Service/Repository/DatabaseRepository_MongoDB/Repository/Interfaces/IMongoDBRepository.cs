namespace DemoMS.Service.Repository.DatabaseRepository_MongoDB.Repository.Interfaces
{
    public interface IMongoDBRepository<T> where T : class
    {
        Task AddDataAsync(T item);
        Task DeleteDataAsync(Guid id);
        Task<IReadOnlyCollection<T>> GetAllDataAsync();
        Task<T> GetDataByIDAsync(Guid id);
        Task UpdateDataAsync(T item);
    }
}