using Repo.Attributes;

namespace BusinessApplication.DTO
{
    public class PricebookGetDTO
    {
        public int ID { get; set; }
        [EntityCode]
        public string? PricebookCode { get; set; }
        public string? PricebookName { get; set; }
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
        public List<ProductGetDTO> Products { get; set; }
    }
}
