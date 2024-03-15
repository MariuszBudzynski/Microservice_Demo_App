using DemoMS.Service.Repository.DatabaseRepository_MongoDB.Entities;
using DemoMS.Service.Repository.DatabaseRepository_MongoDB.Repository.Interfaces;
using DemoMS.Service.Repository.DatabaseRepository_MongoDB.UseCases.Interfaces;

namespace DemoMS.Service.Repository.DatabaseRepository_MongoDB.UseCases
{
    public class DeleteDataUseCase : IDeleteDataUseCase
    {
        private readonly IMongoDBRepository<Item> _dBRepository;

        public DeleteDataUseCase(IMongoDBRepository<Item> dBRepository)
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
