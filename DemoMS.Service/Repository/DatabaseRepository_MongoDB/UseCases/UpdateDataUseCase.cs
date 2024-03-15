using DemoMS.Service.Repository.DatabaseRepository_MongoDB.Entities;
using DemoMS.Service.Repository.DatabaseRepository_MongoDB.Repository.Interfaces;
using DemoMS.Service.Repository.DatabaseRepository_MongoDB.UseCases.Interfaces;

namespace DemoMS.Service.Repository.DatabaseRepository_MongoDB.UseCases
{
    public class UpdateDataUseCase : IUpdateDataUseCase<Item>
    {
        private readonly IMongoDBRepository<Item> _dBRepository;

        public UpdateDataUseCase(IMongoDBRepository<Item> dBRepository)
        {
            _dBRepository = dBRepository;
        }

        public async Task<IResult> ExecuteAsync(Item item)
        {
            if (item == null)
            {
                return Results.NotFound("Item not found");
            }
            else
            {
                await _dBRepository.UpdateDataAsync(item);
                return Results.Ok();
            }
        }


    }
}
