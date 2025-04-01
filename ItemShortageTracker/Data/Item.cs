using System.ComponentModel.DataAnnotations.Schema;

namespace ItemShortageTracker.Data
{
    public class Item
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ShortageStatus ShortageStatus { get; set; }

        public DateTime LastUpdatedAt { get; set; }

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
    }
}
