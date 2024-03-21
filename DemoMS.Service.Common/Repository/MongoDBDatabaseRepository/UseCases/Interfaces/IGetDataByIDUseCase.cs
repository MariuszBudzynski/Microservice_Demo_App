namespace DemoMS.Service.Common.Repository.MongoDBDatabaseRepository.UseCases.Interfaces
{
    public interface IGetDataByIDUseCase<T> where T : IEntity
    {
        Task<IResult> ExecuteAsync(Guid id);
        Task<IResult> ExecuteAsync(Expression<Func<T, bool>> filter);
    }
}