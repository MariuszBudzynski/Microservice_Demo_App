using DemoMS.Service.Repository.DatabaseRepository_MongoDB.Entities;
using DemoMS.Service.Repository.DatabaseRepository_MongoDB.Repository.Interfaces;
using DemoMS.Service.Repository.DatabaseRepository_MongoDB.UseCases.Interfaces;

namespace DemoMS.Service.Repository.DatabaseRepository_MongoDB.UseCases
{
    public class AddDataUseCase : IAddDataUseCase<Item>
    {
        private readonly IMongoDBRepository<Item> _dBRepository;

        public AddDataUseCase(IMongoDBRepository<Item> dBRepository)
        {
            _dBRepository = dBRepository;
        }

        public async Task<IResult> ExecuteAsync(Item item)
        {
            await _dBRepository.AddDataAsync(item);
            return Results.Ok(item);
        }
    }
}
