using DemoMS.Service.Catalog.Repository.DatabaseRepository_MongoDB.Entities.Interfaces;

namespace DemoMS.Service.Repository.DatabaseRepository_MongoDB.Repository.Interfaces
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