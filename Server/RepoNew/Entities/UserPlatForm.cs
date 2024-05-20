using Repo.Attributes;
using Repo.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repo.Entities
{
    [Table("user_platform")]
    public class UserPlatForm : BaseEntity
    {
        public string FullName { get; set; }
        public string Avatar { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsAllowAccess { get; set; }
        /// <summary>
        /// Mapping 2 bảng
        /// </summary>
        [NoInsert]
        [NoUpdate]
        public List<Company> Companys { get; set; }
    }
}
