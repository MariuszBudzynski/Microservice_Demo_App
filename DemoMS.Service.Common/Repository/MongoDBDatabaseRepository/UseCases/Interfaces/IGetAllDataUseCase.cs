namespace DemoMS.Service.Common.Repository.MongoDBDatabaseRepository.UseCases.Interfaces
{
    public interface IGetAllDataUseCase<T> where T : IEntity
    {
        Task<IResult> ExecuteAsync();
        Task<IResult> ExecuteAsync(Expression<Func<T, bool>> filter);
    }
}