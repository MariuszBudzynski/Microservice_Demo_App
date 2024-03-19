using DemoMS.Service.Catalog.Repository.DatabaseRepository_MongoDB.Entities.Interfaces;
using DemoMS.Service.Repository.DatabaseRepository_MongoDB.Repository.Interfaces;
using DemoMS.Service.Repository.DatabaseRepository_MongoDB.UseCases.Interfaces;

namespace DemoMS.Service.Repository.DatabaseRepository_MongoDB.UseCases
{
    public class GetAllDataUseCase<T> : IGetAllDataUseCase where T : IEntity
    {
        private readonly IMongoDBRepository<T> _dBRepository;

        public GetAllDataUseCase(IMongoDBRepository<T> dBRepository)
        {
            _dBRepository = dBRepository;
        }

        public async Task<IResult> ExecuteAsync()
        {
            var data = await _dBRepository.GetAllDataAsync();
            return Results.Ok(data);
        }
    }
}
