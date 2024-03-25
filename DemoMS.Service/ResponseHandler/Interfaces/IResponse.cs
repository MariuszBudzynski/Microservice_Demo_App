namespace DemoMS.Service.Catalog.ResponseHandler.Interfaces
{
    public interface IResponse
    {
        Task<IResult> ReturnResultAsync(CreatedItemDto item, IAddDataUseCase<Item> addDataUseCase);
        Task<IResult> ReturnResultAsync(Guid id, IDeleteDataUseCase<Item> deleteDataUseCase);
        Task<IResult> ReturnResultAsync(Guid id, IGetDataByIDUseCase<Item> getDataByIDUseCase);
        Task<IResult> ReturnResultAsync(Guid id, UpdateItemDTO item, IUpdateDataUseCase<Item> updateDataUseCase);
        Task<IResult> ReturnResultAsync(IGetAllDataUseCase<Item> getAllDataUseCase);
    }
}