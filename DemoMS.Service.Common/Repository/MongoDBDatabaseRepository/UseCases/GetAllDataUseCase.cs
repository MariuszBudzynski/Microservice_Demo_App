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
            try
            {
                var data = await _dBRepository.GetAllDataAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IReadOnlyCollection<T>> ExecuteAsync(Expression<Func<T, bool>> filter)
        {
            try
            {
                var data = await _dBRepository.GetAllDataAsync(filter);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
