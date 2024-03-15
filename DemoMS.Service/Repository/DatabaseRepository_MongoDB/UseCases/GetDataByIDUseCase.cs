using DemoMS.Service.Repository.DatabaseRepository_MongoDB.Entities;
using DemoMS.Service.Repository.DatabaseRepository_MongoDB.Repository.Interfaces;
using DemoMS.Service.Repository.DatabaseRepository_MongoDB.UseCases.Interfaces;

namespace DemoMS.Service.Repository.DatabaseRepository_MongoDB.UseCases
{
    public class GetDataByIDUseCase : IGetDataByIDUseCase
    {
        private readonly IMongoDBRepository<Item> _dBRepository;

        public GetDataByIDUseCase(IMongoDBRepository<Item> dBRepository)
        {
            _dBRepository = dBRepository;
        }

        public async Task<IResult> ExecuteAsync(Guid id)
        {
            var data = await _dBRepository.GetDataByIDAsync(id);
            if (data == null)
            {
                return Results.NotFound("No data found");
            }
            else return Results.Ok(data);
        }
    }
}
