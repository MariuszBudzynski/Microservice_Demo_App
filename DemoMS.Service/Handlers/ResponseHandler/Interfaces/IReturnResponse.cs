namespace DemoMS.Service.Catalog.Handlers.ResponseHandler.Interfaces
{
    public interface IReturnResponse
    {
        Task<IResult> ReturnResultAfterDeleteAsync(Guid id);
        Task<IResult> ReturnResultAsync();
        Task<IResult> ReturnResultAsync(CreatedItemDto item);
        Task<IResult> ReturnResultAsync(Guid id);
        Task<IResult> ReturnResultAsync(Guid id, UpdateItemDTO item);
    }
}