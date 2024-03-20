namespace DemoMS.Service.Common.Repository.MongoDBDatabaseRepository.UseCases.Interfaces
{
    public interface IGetAllDataUseCase
    {
        Task<IResult> ExecuteAsync();
    }
}