using DemoMS.Service.DTOS;
using DemoMS.Service.Repository.InMemory.InMemoryUseCases.Interfaces;
using DemoMS.Service.Repository.InMemory.UseCases.Interfaces;

namespace DemoMS.Service
{
    public static class InMemoryRoutes
    {
        public static void ConfigureInMemoryRoutes(WebApplication app)
        {
            app.MapGet("/items", (IInMemoryGetAllIUseCase<ItemDto> inMemoryGetAllIUseCase) =>
            {
                return inMemoryGetAllIUseCase.Execute();
            });

            app.MapGet("/items/{id}", (Guid id, IInMemoryGetDataByIDUseCase<ItemDto> inMemoryGetDataByIDUseCase) =>
            {
                return inMemoryGetDataByIDUseCase.Execute(id);
            });

            app.MapPost("/items", (ItemDto item, IInMemoryAddDataUseCase<ItemDto> inMemoryAddDataUseCase) =>
            {
                inMemoryAddDataUseCase.Execute(item);
            });

            app.MapPut("/items{id}", (ItemDto data, IInMemoryUpdateDataUseCase<ItemDto> inMemoryUpdateDataUseCase) =>
            {
                inMemoryUpdateDataUseCase.Execute(data);
            });

            app.MapDelete("/items{id}", (Guid id, IInMemoryDeleteDataUseCase<ItemDto> inMemoryDeleteDataUseCase) =>
            {
                return inMemoryDeleteDataUseCase.Execute(id);
            });
        }
    }
}
