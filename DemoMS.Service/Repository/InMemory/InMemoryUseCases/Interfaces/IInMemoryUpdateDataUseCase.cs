using DemoMS.Service.DTOS;

namespace DemoMS.Service.Repository.InMemory.InMemoryUseCases.Interfaces
{
    public interface IInMemoryUpdateDataUseCase<T> where T: class
    {
        IResult Execute(Guid id, T item);

    }
}