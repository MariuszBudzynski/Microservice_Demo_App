using DemoMS.Service.DTOS;

namespace DemoMS.Service.Repository.InMemory.InMemoryUseCases.Interfaces
{
    public interface IInMemoryAddDataUseCase<T> where T : CreatedItemDto
    {
        IResult Execute(T data);
    }
}