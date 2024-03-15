namespace DemoMS.Service.Repository.DatabaseRepository_MongoDB.UseCases.Interfaces
{
    public interface IDeleteDataUseCase
    {
        Task<IResult> ExecuteAsync(Guid id);
    }
}