using DemoMS.Service.DTOS;
using DemoMS.Service.Repository.InMemory.InMemoryUseCases.Interfaces;
using DemoMS.Service.Repository.InMemory.UseCases.Interfaces;
using FluentValidation;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

            app.MapPost("/items", (IValidator<CreatedItemDto> validator, CreatedItemDto item, IInMemoryAddDataUseCase<CreatedItemDto> inMemoryAddDataUseCase) =>
            {
                //i am not using async version here , the async will be used in normal DB implementation
                //setting up custom validation
                var validation = validator.Validate(item);

                if (validation.IsValid)
                {
                    inMemoryAddDataUseCase.Execute(item);
                }

                return Results.ValidationProblem(validation.ToDictionary());

            });

            app.MapPut("/items{id}", (IValidator<UpdateItemDTO> validator, Guid id,UpdateItemDTO item, IInMemoryUpdateDataUseCase<UpdateItemDTO> inMemoryUpdateDataUseCase) =>
            {
                var validation = validator.Validate(item);
                if (validation.IsValid)
                {
                    inMemoryUpdateDataUseCase.Execute(id, item);
                }

                return Results.ValidationProblem(validation.ToDictionary());
            });

            app.MapDelete("/items{id}", (Guid id, IInMemoryDeleteDataUseCase<ItemDto> inMemoryDeleteDataUseCase) =>
            {
                return inMemoryDeleteDataUseCase.Execute(id);
            });
        }
    }
}
