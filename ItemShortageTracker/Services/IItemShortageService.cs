using ItemShortageTracker.Data;

namespace ItemShortageTracker.Services
{
    public interface IItemShortageService
    {
        Task SaveItem(List<Item> items);

        Task<List<Item>> GetAllItems();

        Task AddNewItem(Item item);
    }
}
