namespace DemoMS.Service.Inventory.ResponseHandler.Interfaces
{
    public interface IReturnResponse
    {
        Task<IResult> ReturnResultAsync(GrantItemsDTO grantItemsDTO);
        Task<IResult> ReturnResultAsync(Guid id);
    }
}