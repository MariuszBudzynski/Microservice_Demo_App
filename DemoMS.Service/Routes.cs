using DemoMS.Service.DTOS;
using DemoMS.Service.Extensions;
using DemoMS.Service.Repository.DatabaseRepository_MongoDB.Entities;
using DemoMS.Service.Repository.DatabaseRepository_MongoDB.UseCases.Interfaces;
using FluentValidation;

namespace DemoMS.Service
{
    public static class Routes
    {
        public static void ConfigureRoutes(WebApplication app)
        {
            app.MapGet("/items", async (IGetAllDataUseCase getAllDataUseCase) =>
            {
                return await getAllDataUseCase.ExecuteAsync();
            });

            app.MapGet("/items/{id}", async (Guid id, IGetDataByIDUseCase getDataByIDUseCase) =>
            {
                return await getDataByIDUseCase.ExecuteAsync(id);
            });

            app.MapPost("/items", async (IValidator<CreatedItemDto> validator, CreatedItemDto item, IAddDataUseCase<Item> addDataUseCase) =>
            {
                //i am not using async version here , the async will be used in normal DB implementation
                //setting up custom validation
                var validation = validator.Validate(item);

                if (validation.IsValid)
                {
                   await addDataUseCase.ExecuteAsync(item.CreatedItemDtoToItem());
                }

                return Results.ValidationProblem(validation.ToDictionary());

            });

            app.MapPut("/items/{id}", async (IValidator<UpdateItemDTO> validator, Guid id, UpdateItemDTO item,
                                      IUpdateDataUseCase<Item> updateDataUseCase) =>
            {
                var validation = validator.Validate(item);
                if (validation.IsValid)
                {
                   await updateDataUseCase.ExecuteAsync(item.UpdateddItemDtoToItem());
                }

                return Results.ValidationProblem(validation.ToDictionary());
            });

            app.MapDelete("/items/{id}", async (Guid id, IDeleteDataUseCase deleteDataUseCase) =>
            {
                return await deleteDataUseCase.ExecuteAsync(id);
            });
        }
    }
}
