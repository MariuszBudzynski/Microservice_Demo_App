using DemoMS.Service.DTOS;

namespace DemoMS.Service.Repository.InMemory.InMemoryUseCases.Interfaces
{
    public interface IInMemoryAddDataUseCase<T> where T : class
    {
        IResult Execute(T data);
    }
}