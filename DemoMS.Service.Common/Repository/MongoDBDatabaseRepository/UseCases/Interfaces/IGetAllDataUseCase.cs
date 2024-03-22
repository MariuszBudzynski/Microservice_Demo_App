namespace DemoMS.Service.Common.Repository.MongoDBDatabaseRepository.UseCases.Interfaces
{
    public interface IGetAllDataUseCase<T> where T : IEntity
    {
        Task<IReadOnlyCollection<T>> ExecuteAsync();
        Task<IReadOnlyCollection<T>> ExecuteAsync(Expression<Func<T, bool>> filter);
    }
}