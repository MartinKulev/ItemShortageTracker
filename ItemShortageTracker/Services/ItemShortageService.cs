using ItemShortageTracker.Data;
using Microsoft.EntityFrameworkCore;

namespace ItemShortageTracker.Services
{
    public class ItemShortageService : IItemShortageService
    {
        private readonly ItemShortageTrackerDbContext _itemShortageTrackerDbContext;

        public ItemShortageService(ItemShortageTrackerDbContext itemShortageTrackerDbContext)
        {
            _itemShortageTrackerDbContext = itemShortageTrackerDbContext;
        }

        public async Task SaveItem(List<Item> items)
        {
            _itemShortageTrackerDbContext.UpdateRange(items);
            await _itemShortageTrackerDbContext.SaveChangesAsync();
        }

        public async Task<List<Item>> GetAllItems(int categoryId)
        {
           return await _itemShortageTrackerDbContext.Items
                .Where(i => i.CategoryId == categoryId)
                .ToListAsync();
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _itemShortageTrackerDbContext.Categories
                 .ToListAsync();
        }

        public async Task AddNewItem(Item item)
        {
            await _itemShortageTrackerDbContext.AddAsync(item);
            await _itemShortageTrackerDbContext.SaveChangesAsync();
        }
    }
}
