namespace ItemShortageTracker.Data
{
    public class Item
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ShortageStatus ShortageStatus { get; set; }

        public DateTime LastUpdatedAt { get; set; }
    }
}
