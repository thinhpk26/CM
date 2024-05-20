using Repo.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repo.Entities
{
    [Table("product")]
    public class Product : BaseEntity
    {
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
        [NoUpdate]
        [NoInsert]
        public List<Pricebook> Pricebook { get; set; }
    }
}
