namespace DemoMS.Service.Common.Repository.MongoDBDatabaseRepository.UseCases.Interfaces
{
    public interface IDeleteDataUseCase
    {
        Task<IResult> ExecuteAsync(Guid id);
    }
}