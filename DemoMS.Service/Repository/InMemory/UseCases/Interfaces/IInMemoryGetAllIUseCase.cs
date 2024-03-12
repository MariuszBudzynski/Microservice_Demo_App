using DemoMS.Service.DTOS;

namespace DemoMS.Service.Repository.InMemory.UseCases.Interfaces
{
    public interface IInMemoryGetAllIUseCase<T> where T : class
    {
        IEnumerable<T> Execute();
    }
}