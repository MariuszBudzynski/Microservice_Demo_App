﻿namespace DemoMS.Service.Common.Repository.MongoDBDatabaseRepository.UseCases.Interfaces
{
    public interface IUpdateDataUseCase<T> where T : IEntity
    {
        Task<T> ExecuteAsync(T item,Guid id);
    }
}