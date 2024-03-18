namespace DemoMS.Service.Repository.DatabaseRepository_MongoDB.UseCases.Interfaces
{
    public interface IGetAllDataUseCase
    {
        Task<IResult> ExecuteAsync();
    }
}