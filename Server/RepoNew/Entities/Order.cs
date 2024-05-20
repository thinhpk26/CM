using Repo.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repo.Entities
{
    [Table("order")]
    public class Order : BaseEntity
    {
        [EntityCode]
        public string? OrderCode { get; set; }
        public string? OrderName { get; set; }
		public long? AccountID { get; set; }
		public string? AccountName { get; set; }
		public DateTimeOffset? BookDate { get; set; }
		public DateTimeOffset? PaiedDate { get; set; }
		public decimal? PaiedActual { get; set; }
		public decimal? OrderValue { get; set; }
		public string? Description { get; set; }
		public int PaiedStateID { get; set; }
		public string? PaiedStateIDText { get; set; }
		public int StateID { get; set; }
		public string? StateIDText { get; set; }
		public int ShippingStateID { get; set; }
		public string? ShippingStateIDText { get; set; }
		public int UserID { get; set; }
		public string? UserName { get; set; }
		public string? AddressInvoice { get; set; }
		public string? AddressShipping { get; set; }
		public long ContactID { get; set; }
		public string? ContactIDText { get; set; }
		public bool? IsDeleted { get; set; }
        [NoInsert]
        [NoUpdate]
        public List<OrderProductMapping>? Products { get; set; }
    }
}
