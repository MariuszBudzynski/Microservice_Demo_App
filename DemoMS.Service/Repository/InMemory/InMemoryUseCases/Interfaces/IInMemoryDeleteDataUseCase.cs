using Microsoft.AspNetCore.Mvc;

namespace DemoMS.Service.Repository.InMemory.InMemoryUseCases.Interfaces
{
    public interface IInMemoryDeleteDataUseCase<T> where T : class
    {
        IResult Execute(Guid id);
    }
}