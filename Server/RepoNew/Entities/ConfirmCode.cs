using Repo.Attributes;
using Repo.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repo.Entities
{
    [Table("confirm_code")]
    public class ConfirmCode : BaseEntity
    {
        [Column("ConfirmCode")]
        public Guid Code { get; set; }
        public DateTimeOffset CreateTime { get; set; }
        public long Timeout { get; set; }
        public bool IsUsed { get; set; }
        [NoUpdate]
        [ForeignEntity("ID", "CompanyID")]
        [InsertField("CompanyCode", "CompanyCode")]
        public Company Company { get; set; }
    }
}
