using ItemShortageTracker.Data;

namespace ItemShortageTracker.Services
{
    public interface IItemShortageService
    {
        Task SaveItem(List<Item> items);

        Task<List<Item>> GetAllItems(int categoryId);

        Task<List<Category>> GetAllCategories();

        Task AddNewItem(Item item);
    }
}
