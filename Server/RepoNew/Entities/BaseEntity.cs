using Repo.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Repo.Entities
{
    public class BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key]
        [NoInsert]
        [NoUpdate]
        public long ID { get; set; }
        /// <summary>
        /// Người tạo
        /// </summary>
        public string? CreatedBy { get; set; }
        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTimeOffset? CreatedDate { get; set; }
        /// <summary>
        /// Người sửa
        /// </summary>
        public string? ModifiedBy { get; set; }
        /// <summary>
        /// Ngày sửa
        /// </summary>
        public DateTimeOffset? ModifiedDate { get; set; }
    }
}
