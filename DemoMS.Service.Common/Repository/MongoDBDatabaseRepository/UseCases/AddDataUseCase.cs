namespace DemoMS.Service.Common.Repository.MongoDBDatabaseRepository.UseCases
{
    public class AddDataUseCase<T> : IAddDataUseCase<T> where T : IEntity
    {
        private readonly IMongoDBRepository<T> _dBRepository;

        public AddDataUseCase(IMongoDBRepository<T> dBRepository)
        {
            _dBRepository = dBRepository;
        }

        public async Task ExecuteAsync(T item)
        {
            try
            {
                await _dBRepository.AddDataAsync(item);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
