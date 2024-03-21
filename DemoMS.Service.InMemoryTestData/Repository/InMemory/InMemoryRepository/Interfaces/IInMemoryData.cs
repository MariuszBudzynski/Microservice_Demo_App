namespace DemoMS.Service.Repository.InMemory.InMemoryRepository.Interfaces
{
    public interface IInMemoryData<T,U> where T : class where U : class
    {
        IEnumerable<T> GetAllData();
        T GetDataByID(Guid id);
        void AddData(T data);
        void DeleteData(Guid id);
        void UpdateData(Guid id, U item);
    }
}