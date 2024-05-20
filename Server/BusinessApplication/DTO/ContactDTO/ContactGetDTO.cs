using Repo.Attributes;

namespace BusinessApplication.DTO
{
    public class ContactGetDTO
    {
        public int ID { get; set; }
        /// <summary>
        /// mã liên hệ
        /// </summary>
        [EntityCode]
        public string? ContactCode { get; set; }

        /// <summary>
        /// tên liên hệ
        /// </summary>
        public string? ContactName { get; set; }

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
        /// địa chỉ
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// số điện thoại
        /// </summary>
        /// <returns></returns>
        public string? PhoneNumber { get; set; }

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
    }
}
