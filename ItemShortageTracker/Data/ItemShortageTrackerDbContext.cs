using Microsoft.EntityFrameworkCore;

namespace ItemShortageTracker.Data
{
    public class ItemShortageTrackerDbContext : DbContext
    {
        public ItemShortageTrackerDbContext(DbContextOptions<ItemShortageTrackerDbContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}
