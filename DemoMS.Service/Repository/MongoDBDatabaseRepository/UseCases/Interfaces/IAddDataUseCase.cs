using DemoMS.Service.Catalog.Repository.DatabaseRepository_MongoDB.Entities.Interfaces;

namespace DemoMS.Service.Repository.DatabaseRepository_MongoDB.UseCases.Interfaces
{
    public interface IAddDataUseCase<T> where T : IEntity
    {
        Task<IResult> ExecuteAsync(T item);
    }
}