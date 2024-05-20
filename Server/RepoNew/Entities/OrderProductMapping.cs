using Repo.Attributes;
using Repo.Models;

namespace Repo.Entities
{
    public class OrderProductMapping
    {
        public long ID { get; set; }
        public long OrderID { get; set; }
        public string? OrderText { get; set; }
        [NoInsert]
        [NoUpdate]
        public string? ProductCode { get; set; }
        public long ProductID { get; set; }
        public string? ProductText { get; set; }
        public int UnitID { get; set; }
        public string? UnitText { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public int TaxID { get; set; }
        public string? TaxIDText { get; set; }
        public decimal MoneyAfterTax { get; set; }
        public decimal Discount { get; set; }
        public decimal MoneyAfterDiscount { get; set; }
        public decimal TotalMoney { get; set; }
        public int Amount { get; set; }
    }
}
