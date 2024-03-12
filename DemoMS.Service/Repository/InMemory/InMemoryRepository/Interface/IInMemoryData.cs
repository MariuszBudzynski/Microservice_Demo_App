namespace DemoMS.Service.Repository.InMemory.InMemoryRepository.Interface
{
    public interface IInMemoryData<T> where T : class
    {
        IEnumerable<T> GetAllData();
    }
}