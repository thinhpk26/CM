namespace Repo.Entities
{
    public class PricebookProductMapping
    {
        public long? ID { get; set; }
        public long? PricebookID { get; set; }
        public long? ProductID { get; set; }
        public string? ProductIDText { get; set;  }
        public decimal? Price { get; set; }
        public int? Discount { get; set; }
    }
}
