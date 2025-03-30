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

        public async Task<List<Item>> GetAllItems()
        {
           return await _itemShortageTrackerDbContext.Items.ToListAsync();
        }

        public async Task AddNewItem(Item item)
        {
            await _itemShortageTrackerDbContext.AddAsync(item);
            await _itemShortageTrackerDbContext.SaveChangesAsync();
        }
    }
}
