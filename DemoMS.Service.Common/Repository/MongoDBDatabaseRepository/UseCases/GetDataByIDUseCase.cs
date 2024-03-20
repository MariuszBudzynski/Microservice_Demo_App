namespace DemoMS.Service.Common.Repository.MongoDBDatabaseRepository.UseCases
{
    public class GetDataByIDUseCase<T> : IGetDataByIDUseCase where T : IEntity
    {
        private readonly IMongoDBRepository<T> _dBRepository;

        public GetDataByIDUseCase(IMongoDBRepository<T> dBRepository)
        {
            _dBRepository = dBRepository;
        }

        public async Task<IResult> ExecuteAsync(Guid id)
        {
            var data = await _dBRepository.GetDataByIDAsync(id);
            if (data == null)
            {
                return Results.NotFound("No data found");
            }
            else return Results.Ok(data);

        }
    }
}
