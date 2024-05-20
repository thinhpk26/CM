using Repo.Attributes;
using Repo.Entities;

namespace AuthAppication.DTO.CompanyDTO
{
    public class CompanyGetDTO
    {
        public long ID { get; set; }
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
        /// <summary>
        /// Mapping 2 bảng
        /// </summary>
        public bool IsAllowAccess { get; set; }
        [NoInsert]
        [NoUpdate]
        public List<UserPlatForm> Users { get; set; }
    }
}
