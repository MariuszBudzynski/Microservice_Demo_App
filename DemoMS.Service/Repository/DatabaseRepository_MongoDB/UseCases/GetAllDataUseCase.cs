using DemoMS.Service.Extensions;
using DemoMS.Service.Repository.DatabaseRepository_MongoDB.Entities;
using DemoMS.Service.Repository.DatabaseRepository_MongoDB.Repository.Interfaces;
using DemoMS.Service.Repository.DatabaseRepository_MongoDB.UseCases.Interfaces;

namespace DemoMS.Service.Repository.DatabaseRepository_MongoDB.UseCases
{
    public class GetAllDataUseCase : IGetAllDataUseCase
    {
        private readonly IMongoDBRepository<Item> _dBRepository;

        public GetAllDataUseCase(IMongoDBRepository<Item> dBRepository)
        {
            _dBRepository = dBRepository;
        }

        public async Task<IResult> ExecuteAsync()
        {
            var data = (await _dBRepository.GetAllDataAsync()).Select(item=>item.ItemToItemDTO());
            return Results.Ok(data);
        }
    }
}
