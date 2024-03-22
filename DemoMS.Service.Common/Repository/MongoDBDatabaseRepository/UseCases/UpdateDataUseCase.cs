namespace DemoMS.Service.Common.Repository.MongoDBDatabaseRepository.UseCases
{
    public class UpdateDataUseCase<T> : IUpdateDataUseCase<T> where T : IEntity
    {
        private readonly IMongoDBRepository<T> _dBRepository;

        public UpdateDataUseCase(IMongoDBRepository<T> dBRepository)
        {
            _dBRepository = dBRepository;
        }

        public async Task<T> ExecuteAsync(T item,Guid id)
        {
            var data = await _dBRepository.GetDataByIDAsync(id);

            if (data == null)
            {
                return data;
            }
            else
            {
                await _dBRepository.UpdateDataAsync(item, id);
                return data;
            }
        }


    }
}
