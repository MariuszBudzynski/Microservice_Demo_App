namespace DemoMS.Service.Common.Repository.MongoDBDatabaseRepository.UseCases
{
    public class GetAllDataUseCase<T> : IGetAllDataUseCase<T> where T : IEntity
    {
        private readonly IMongoDBRepository<T> _dBRepository;

        public GetAllDataUseCase(IMongoDBRepository<T> dBRepository)
        {
            _dBRepository = dBRepository;
        }

        public async Task<IReadOnlyCollection<T>> ExecuteAsync()
        {
            var data = await _dBRepository.GetAllDataAsync();
            return data;
        }

        public async Task<IReadOnlyCollection<T>> ExecuteAsync(Expression<Func<T, bool>> filter)
        {
            var data = await _dBRepository.GetAllDataAsync(filter);
            return data;
        }
    }
}
