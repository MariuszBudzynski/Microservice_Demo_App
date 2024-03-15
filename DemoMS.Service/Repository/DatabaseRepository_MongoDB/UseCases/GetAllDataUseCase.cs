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

        public async Task<IResult> ExecuteAsync(Guid id)
        {
            var data = await _dBRepository.GetAllDataAsync();
            return Results.Ok(data);
        }
    }
}
