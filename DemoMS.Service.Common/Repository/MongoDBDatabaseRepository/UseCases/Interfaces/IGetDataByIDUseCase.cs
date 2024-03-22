namespace DemoMS.Service.Common.Repository.MongoDBDatabaseRepository.UseCases.Interfaces
{
    public interface IGetDataByIDUseCase<T> where T : IEntity
    {
        Task<T> ExecuteAsync(Guid id);
        Task<T> ExecuteAsync(Expression<Func<T, bool>> filter);
    }
}