using DemoMS.Service.Catalog.Repository.DatabaseRepository_MongoDB.Entities.Interfaces;
using DemoMS.Service.Repository.DatabaseRepository_MongoDB.Entities;
using DemoMS.Service.Repository.DatabaseRepository_MongoDB.Repository.Interfaces;
using DemoMS.Service.Repository.DatabaseRepository_MongoDB.UseCases.Interfaces;

namespace DemoMS.Service.Repository.DatabaseRepository_MongoDB.UseCases
{
    public class DeleteDataUseCase<T> : IDeleteDataUseCase where T : IEntity
    {
        private readonly IMongoDBRepository<T> _dBRepository;

        public DeleteDataUseCase(IMongoDBRepository<T> dBRepository)
        {
            _dBRepository = dBRepository;
        }

        public async Task<IResult> ExecuteAsync(Guid id)
        {
            var data = await _dBRepository.GetDataByIDAsync(id);

            if (data == null)
            {
                return Results.NotFound("No item found");
            }
            else
            {
                await _dBRepository.DeleteDataAsync(id);
                return Results.Ok();
            }

        }


    }
}
