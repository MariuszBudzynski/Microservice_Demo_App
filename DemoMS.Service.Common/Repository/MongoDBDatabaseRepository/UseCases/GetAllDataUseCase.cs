namespace DemoMS.Service.Common.Repository.MongoDBDatabaseRepository.UseCases
{
    public class GetAllDataUseCase<T> : IGetAllDataUseCase<T> where T : IEntity
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

        public async Task<IResult> ExecuteAsync(Expression<Func<T, bool>> filter)
        {
            var data = await _dBRepository.GetAllDataAsync(filter);
            return Results.Ok(data);
        }
    }
}
