using DemoMS.Service.DTOS;

namespace DemoMS.Service.Repository.InMemory.InMemoryRepository.Interface
{
    public interface IInMemoryData<T> where T : class
    {
        IEnumerable<T> GetAllData();
        T GetDataByID(Guid id);
        void AddData(T data);
        void DeleteData(Guid id);
        void UpdateData(Guid id, UpdateItemDTO item);
    }
}