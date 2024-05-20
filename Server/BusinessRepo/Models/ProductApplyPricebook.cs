using Repo.Entities;

namespace BusinessRepo.Models
{
    public class ProductApplyPricebook : Product
    {
        public decimal MoneyAfterDiscount { get; set; }
        public decimal MoneyAfterTax { get; set; }
        public decimal TotalMoney { get; set; }
    }
}
