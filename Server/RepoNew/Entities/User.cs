using Repo.Entities;
using Repo.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repo.Entities
{
    [Table("user")]
    public class User : BaseEntity
    {
        [EntityCode]
        public string UserCode { get; set; }
        public string FullName { get; set; }
        public string Avatar { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string PositionName { get; set; }
        public bool IsActive { get; set; }
        public long RoleID { get; set; }
        public string RoleName {get; set; }
        [NoUpdate]
        [NoInsert]
        public long UserPlatformID { get; set; }
        [NoUpdate]
        [ForeignEntity("ID", "UserPlatformID")]
        public UserPlatForm UserPlatform { get; set; }
    }
}
