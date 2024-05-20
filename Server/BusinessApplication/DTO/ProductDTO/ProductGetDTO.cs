using Repo.Attributes;

namespace BusinessApplication.DTO
{
    public class ProductGetDTO
    {
        public int ID { get; set; }
        [EntityCode]
        public string? ProductCode { get; set; }
        public string? ProductName { get; set; }
        public int? UnitID { get; set; }
        public string? UnitText { get; set; }
        public decimal? Price { get; set; }
        public string? Description { get; set; }
        public int? TaxID { get; set; }
        public string? TaxIDText { get; set; }
        public string? Discount { get; set; }
    }
}
