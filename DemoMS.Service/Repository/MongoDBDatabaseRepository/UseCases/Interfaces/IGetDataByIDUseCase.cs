namespace DemoMS.Service.Repository.DatabaseRepository_MongoDB.UseCases.Interfaces
{
    public interface IGetDataByIDUseCase
    {
        Task<IResult> ExecuteAsync(Guid id);
    }
}