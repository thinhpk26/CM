namespace AuthAppication.DTO
{
    public class UserPlatFormInsertDTO
    {
        public string FullName { get; set; }
        public string Avatar { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsAllowAccess { get; set; }
    }
}
