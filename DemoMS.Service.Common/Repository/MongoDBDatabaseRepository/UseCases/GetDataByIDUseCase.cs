namespace DemoMS.Service.Common.Repository.MongoDBDatabaseRepository.UseCases
{
    public class GetDataByIDUseCase<T> : IGetDataByIDUseCase<T> where T : IEntity
    {
        private readonly IMongoDBRepository<T> _dBRepository;

        public GetDataByIDUseCase(IMongoDBRepository<T> dBRepository)
        {
            _dBRepository = dBRepository;
        }

        public async Task<T> ExecuteAsync(Guid id)
        {
            var data = await _dBRepository.GetDataByIDAsync(id);
            return data;
        }

        public async Task<T> ExecuteAsync(Expression<Func<T, bool>> filter)
        {
            var data = await _dBRepository.GetDataByIDAsync(filter);
            return data;
        }
    }
}
