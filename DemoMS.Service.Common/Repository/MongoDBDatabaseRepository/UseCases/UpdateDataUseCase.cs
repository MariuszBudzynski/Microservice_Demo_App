namespace DemoMS.Service.Common.Repository.MongoDBDatabaseRepository.UseCases
{
    public class UpdateDataUseCase<T> : IUpdateDataUseCase<T> where T : IEntity
    {
        private readonly IMongoDBRepository<T> _dBRepository;

        public UpdateDataUseCase(IMongoDBRepository<T> dBRepository)
        {
            _dBRepository = dBRepository;
        }

        public async Task<IResult> ExecuteAsync(T item,Guid id)
        {
            if (item == null)
            {
                return Results.NotFound("Item not found");
            }
            else
            {
                await _dBRepository.UpdateDataAsync(item,id);
                return Results.Ok();
            }
        }


    }
}
