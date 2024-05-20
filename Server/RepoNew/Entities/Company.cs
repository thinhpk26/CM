using Repo.Attributes;
using Repo.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repo.Entities
{
    [Table("company")]
    public class Company : BaseEntity
    {
        /// <summary>
        /// Mã công ty
        /// </summary>
        public string CompanyCode { get; set; }
        /// <summary>
        /// Tên công ty
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// Mã số thuế
        /// </summary>
        public string MST { get; set; }
        /// <summary>
        /// Mô tả
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// tên cơ sở dữ liệu đang lưu trữ dữ liệu công ty
        /// </summary>
        public string DBSave { get; set; }
        public bool IsAllowAccess { get; set; }
        /// <summary>
        /// Mapping 2 bảng
        /// </summary>
        [NoInsert]
        [NoUpdate]
        public List<UserPlatForm> Users { get; set; }
    }
}
