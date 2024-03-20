namespace DemoMS.Service.Common.Repository.MongoDBDatabaseRepository.UseCases.Interfaces
{
    public interface IAddDataUseCase<T> where T : IEntity
    {
        Task<IResult> ExecuteAsync(T item);
    }
}