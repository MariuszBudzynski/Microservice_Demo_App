namespace DemoMS.Service.Common.Repository.MongoDBDatabaseRepository.UseCases
{
    public class GetDataByIDUseCase<T> : IGetDataByIDUseCase<T> where T : IEntity
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

        public async Task<IResult> ExecuteAsync(Expression<Func<T, bool>> filter)
        {
            var data = await _dBRepository.GetDataByIDAsync(filter);
            if (data == null)
            {
                return Results.NotFound("No data found");
            }
            else return Results.Ok(data);

        }
    }
}
