namespace DemoMS.Service.Repository.InMemory.UseCases.Interfaces
{
    public interface IInMemoryGetAllIUseCase<T> where T : class
    {
        IResult Execute();
    }
}