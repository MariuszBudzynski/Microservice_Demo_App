using DemoMS.Service.DTOS;

namespace DemoMS.Service.Repository.InMemory.InMemoryRepository.Interface
{
    public interface IInMemoryData<T> where T : class
    {
        IEnumerable<T> GetAllData();
        T GetDataByID(Guid id);
        void AddtData(T data);
        void DeleteData(Guid id);
        void UpdataData<Z>(Guid id,Z item) where Z : UpdateItemDTO;
    }
}