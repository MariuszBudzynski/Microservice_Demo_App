using DemoMS.Service.Catalog.ResponseHandler;
using DemoMS.Service.Common.Repository.MongoDBDatabaseRepository.UseCases.Interfaces;

namespace DemoMS.Service
{
    public static class Routes
    {
        public static void ConfigureRoutes(WebApplication app)
        {
            app.MapGet("/items", async (IGetAllDataUseCase<Item> getAllDataUseCase, MappData mapper, ResponseHandler responseHandler) =>
            {
                return await responseHandler.ReturnResultAsync(getAllDataUseCase,mapper);
            });

            app.MapGet("/items/{id}", async (Guid id, IGetDataByIDUseCase<Item> getDataByIDUseCase, MappData mapper, ResponseHandler responseHandler) =>
            {
                return await responseHandler.ReturnResultAsync(id, getDataByIDUseCase, mapper);
            });

            app.MapPost("/items", async (IValidator<CreatedItemDto> validator, CreatedItemDto item, IAddDataUseCase<Item> addDataUseCase, MappData mapper,
                ResponseHandler responseHandler) =>
            {
                var validation = validator.Validate(item);

                if (validation.IsValid)
                {
                    return await responseHandler.ReturnResultAsync(item,addDataUseCase,mapper);
                }

                else return Results.ValidationProblem(validation.ToDictionary());

            });

            app.MapPut("/items/{id}", async (IValidator<UpdateItemDTO> validator, Guid id, UpdateItemDTO item,
                                      IUpdateDataUseCase<Item> updateDataUseCase, MappData mapper,ResponseHandler responseHandler) =>
            {
                var validation = validator.Validate(item);
                if (validation.IsValid)
                {
                    return await responseHandler.ReturnResultAsync(id,item,updateDataUseCase,mapper);
                }
                else return Results.ValidationProblem(validation.ToDictionary());
            });

            app.MapDelete("/items/{id}", async (Guid id, IDeleteDataUseCase<Item> deleteDataUseCase, ResponseHandler responseHandler) =>
            {
                return await responseHandler.ReturnResultAsync(id,deleteDataUseCase);
            });
        }
    }
}
