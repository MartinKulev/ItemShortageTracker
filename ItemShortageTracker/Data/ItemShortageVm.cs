namespace ItemShortageTracker.Data
{
    public class ItemShortageVm
    {
        public List<Item> Items { get; set; } = new List<Item>();

        public Item NewItem { get; set; } = new Item();
    }
}
