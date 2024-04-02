namespace DemoMS.Service.Inventory.ResponseHandler.Interfaces
{
    public interface IResponse
    {
        Task<IResult> ReturnResultAsync(GrantItemsDTO grantItemsDTO);
        Task<IResult> ReturnResultAsync(Guid id);
    }
}