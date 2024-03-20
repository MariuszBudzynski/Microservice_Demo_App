namespace DemoMS.Service.Common.Repository.MongoDBDatabaseRepository.UseCases
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
