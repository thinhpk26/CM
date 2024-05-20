using Repo.Attributes;
using Repo.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repo.Entities
{
    [Table("layout_Column")]
    public class LayoutColumn : BaseEntity
    {
        public long LayoutID { get; set; }
        public string LayoutCode { get; set; }
        public string Index { get; set; }
        public string Name { get; set; }
        public TypeControl Type { get; set; }
        public int Width { get; set; }
        public bool Sticky { get; set; }
        public bool IsDisplay { get; set; }
        public int Order { get; set; }

        [NoInsert]
        [NoUpdate]
        public string? CreatedBy { get; set; }
        [NoInsert]
        [NoUpdate]
        public DateTimeOffset? CreatedDate { get; set; }
        [NoInsert]
        [NoUpdate]
        public string? ModifiedBy { get; set; }
        [NoInsert]
        [NoUpdate]
        public DateTimeOffset? ModifiedDate { get; set; }
    }
}
