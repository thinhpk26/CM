using Repo.Attributes;
using Repo.Entities;

namespace BusinessApplication.DTO
{
    public class UserGetDTO
    {
        public int ID { get; set; }
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
        public string RoleName { get; set; }
        [NoUpdate]
        [NoInsert]
        public long UserPlatformID { get; set; }
        public UserPlatForm UserPlatform { get; set; }
    }
}
