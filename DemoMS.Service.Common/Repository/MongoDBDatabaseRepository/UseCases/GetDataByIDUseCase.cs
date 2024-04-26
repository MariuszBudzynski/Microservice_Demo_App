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
            try
            {
                var data = await _dBRepository.GetDataByIDAsync(id);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> ExecuteAsync(Expression<Func<T, bool>> filter)
        {
            try
            {
                var data = await _dBRepository.GetDataByIDAsync(filter);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
