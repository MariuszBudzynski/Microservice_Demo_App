namespace DemoMS.Service.Repository.DatabaseRepository_MongoDB.UseCases.Interfaces
{
    public interface IAddDataUseCase<T> where T : class
    {
        Task<IResult> ExecuteAsync(T item);
    }
}