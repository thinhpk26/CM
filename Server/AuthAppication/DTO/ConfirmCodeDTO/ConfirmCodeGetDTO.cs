using Repo.Attributes;
using Repo.Entities;

namespace AuthAppication.DTO.ConfirmCode
{
    public class ConfirmCodeGetDTO
    {
        public Guid Code { get; set; }
        public DateTimeOffset CreateTime { get; set; }
        public long Timeout { get; set; }
        [NoUpdate]
        [ForeignEntity("ID", "CompanyID")]
        [InsertField("CompanyCode", "CompanyCode")]
        public Company Company { get; set; }
    }
}
