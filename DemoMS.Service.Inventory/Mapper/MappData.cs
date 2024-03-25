namespace DemoMS.Service.Inventory.Mapper
{
    public class MappData
    {
        public IReadOnlyCollection<InventoryItemDTO> MappToInventoryItemDTO(IReadOnlyCollection<InventoryItem> dataTomapp)
        {
            return (dataTomapp.Select(x => x.InventoryItemToInventoryItemDTO())).ToList();
        }
    }
}
