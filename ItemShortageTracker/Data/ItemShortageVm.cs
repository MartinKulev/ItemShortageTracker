namespace ItemShortageTracker.Data
{
    public class ItemShortageVm
    {
        public List<Item> Items { get; set; } = new List<Item>();

        public List<Category> Categories { get; set; } = new List<Category>();

        public Item NewItem { get; set; } = new Item();
    }
}
