﻿namespace DemoMS.Service.Catalog.ResponseHandler.Interfaces
{
    public interface IResponse
    {
        Task<IResult> ReturnResultAfterDeleteAsync(Guid id);
        Task<IResult> ReturnResultAsync();
        Task<IResult> ReturnResultAsync(CreatedItemDto item);
        Task<IResult> ReturnResultAsync(Guid id);
        Task<IResult> ReturnResultAsync(Guid id, UpdateItemDTO item);
    }
}