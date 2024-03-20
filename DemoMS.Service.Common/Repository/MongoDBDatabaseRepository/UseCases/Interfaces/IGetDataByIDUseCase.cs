namespace DemoMS.Service.Common.Repository.MongoDBDatabaseRepository.UseCases.Interfaces
{
    public interface IGetDataByIDUseCase
    {
        Task<IResult> ExecuteAsync(Guid id);
    }
}