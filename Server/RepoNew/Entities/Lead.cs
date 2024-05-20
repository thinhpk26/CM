using Repo.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repo.Entities
{
    [Table("lead")]
    public class Lead : BaseEntity
    {
        /// <summary>
        /// mã tiềm năng
        /// </summary>
        [EntityCode]
        public string? LeadCode { get; set; }

        /// <summary>
        /// tên tiềm năng
        /// </summary>
        public string? LeadName { get; set; }

        /// <summary>
        /// ID xưng hô
        /// </summary>
        public int PronounID { get; set; }

        /// <summary>
        /// xưng hô
        /// </summary>
        public string? PronounName { get; set; }

        /// <summary>
        /// mã người dùng
        /// </summary>
        public int? UserID { get; set; }

        /// <summary>
        /// tên người dùng
        /// </summary>
        public string? UserName { get; set; }

        /// <summary>
        /// ID tìm kiếm từ
        /// </summary>
        public int? SearchFromID { get; set; }

        /// <summary>
        /// Text tìm kiếm từ
        /// </summary>
        public string? SearchFrom { get; set; }

        /// <summary>
        /// địa chỉ
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// số điện thoại
        /// </summary>
        /// <returns></returns>
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// lĩnh vực
        /// </summary>
        /// <returns></returns>
        public string? Major { get; set; }

        /// <summary>
        /// email
        /// </summary>
        /// <returns></returns>
        public string? Email { get; set; }

        /// <summary>
        /// ngày sinh/ngày thành lập
        /// </summary>
        public DateTimeOffset? BirthDay { get; set; }

        /// <summary>
        /// giới tính 1. nữ 2.nam 3. không xác định
        /// </summary>
        public int GenderID { get; set; }

        /// <summary>
        /// giới tính 1. nữ 2.nam 3. không xác định
        /// </summary>
        public string? GenderIDText { get; set; }

        /// <summary>
        /// url facebook
        /// </summary>
        /// <returns></returns>
        public string? Facebook { get; set; }

        /// <summary>
        /// url zalo
        /// </summary>
        /// <returns></returns>
        public string? Zalo { get; set; }

        /// <summary>
        /// mô tả/chú thích
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// đã bị xóa chưa
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
