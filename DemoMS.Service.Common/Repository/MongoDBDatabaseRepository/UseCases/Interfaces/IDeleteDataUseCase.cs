namespace DemoMS.Service.Common.Repository.MongoDBDatabaseRepository.UseCases.Interfaces
{
    public interface IDeleteDataUseCase<T> where T : IEntity
    {
        Task<T> ExecuteAsync(Guid id);
    }
}