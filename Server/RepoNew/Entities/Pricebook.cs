using Repo.Attributes;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Repo.Entities
{
    [Table("pricebook")]
    public class Pricebook : BaseEntity
    {
        [EntityCode]
        public string? PricebookCode { get; set; }
        public string PricebookName { get; set; }
        public DateTimeOffset? FromDate { get; set; }
        public DateTimeOffset? ToDate { get; set; }
        public string? Description { get; set; }
        public int AccountObjectID { get; set; }
        public string? AccountObjectIDText { get; set; }
        public string? AccountIDs { get; set; }
        public string? AccountIDsText { get; set; }
        public int UserObjectID { get; set; }
        public string? UserObjectIDText { get; set; }
        public string? UserIDs { get; set; }
        public string? UserIDsText { get; set; }
        [NoInsert]
        [NoUpdate]
        public List<Product>? Products { get; set; }

    }
}
